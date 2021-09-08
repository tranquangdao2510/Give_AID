using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Give_Aid.Models.DataAccess;
using PagedList;

namespace Give_Aid.Areas.Admins.Controllers
{
    public class BlogsController : Controller
    {
        private NgoEntity db = new NgoEntity();

        // GET: Admins/Blogs
        public ActionResult Index(string search_title, int? page)
        {
            page = page ?? 1;
            int pagesize = 5;
            search_title = search_title ?? "";
            ViewBag.search_title = search_title;
            var blogs = db.Blogs.Include(b => b.Tag).Where(x => x.Title.Contains(search_title)).OrderBy(x=>x.BlogId);
            return View(blogs.ToPagedList(page.Value,pagesize));
        }

        // GET: Admins/Blogs/Create
        public ActionResult Create()
        {
            ViewBag.TagId = new SelectList(db.Tags, "TagId", "TagName");
            return View();
        }

        // POST: Admins/Blogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "BlogId,Title,Description,BlogImage,TagId,Content,CreateDate,UpdatedDate,Status")] Blog blog,HttpPostedFileBase fileimage)
        {
            if (ModelState.IsValid)
            {
                if(fileimage != null)
                {
                    fileimage.SaveAs(Server.MapPath("~/Content/assets/images/blogs" + fileimage.FileName));
                    blog.BlogImage = "/Content/assets/images/blogs" + fileimage.FileName;
                }
                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TagId = new SelectList(db.Tags, "TagId", "TagName", blog.TagId);
            return View(blog);
        }

        // GET: Admins/Blogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.TagId = new SelectList(db.Tags, "TagId", "TagName", blog.TagId);
            return View(blog);
        }

        // POST: Admins/Blogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlogId,Title,Description,BlogImage,TagId,Content,CreateDate,UpdatedDate,Status")] Blog blog,HttpPostedFileBase fileimage)
        {
            if (ModelState.IsValid)
            {
                if (fileimage != null)
                {
                    fileimage.SaveAs(Server.MapPath("~/Content/assets/images/blogs" + fileimage.FileName));
                    blog.BlogImage = "/Content/assets/images/blogs" + fileimage.FileName;
                }
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TagId = new SelectList(db.Tags, "TagId", "TagName", blog.TagId);
            return View(blog);
        }

        // GET: Admins/Blogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            db.Blogs.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
