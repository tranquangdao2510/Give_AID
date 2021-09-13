using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Give_Aid.Common;
using Give_Aid.Models.DataAccess;
using PagedList;

namespace Give_Aid.Areas.Admins.Controllers
{
    public class TagsController : BaseController
    {
        private NgoEntity db = new NgoEntity();

        // GET: Admins/Tags

        [HasPermission(RoleId = "VIEW")]
        public ActionResult Index(string search_name, int? page)
        {
            page = page ?? 1;
            int pagesize = 5;
            search_name = search_name ?? "";
            ViewBag.search_name = search_name;
            var tags = db.Tags.ToList().Where(x => x.TagName.Contains(search_name));
            return View(tags.ToPagedList(page.Value,pagesize));
        }


        // GET: Admins/Tags/Create

        [HasPermission(RoleId = "CREATE")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admins/Tags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TagId,TagName,CreateDate,UpdatedDate,Status")] Tag tag)
        {
            if (ModelState.IsValid)
            {
                db.Tags.Add(tag);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tag);
        }

        // GET: Admins/Tags/Edit/5

        [HasPermission(RoleId = "EDIT")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = db.Tags.Find(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        // POST: Admins/Tags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TagId,TagName,CreateDate,UpdatedDate,Status")] Tag tag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tag);
        }

        // GET: Admins/Tags/Delete/5

        [HasPermission(RoleId = "DELETE")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = db.Tags.Find(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            db.Tags.Remove(tag);
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
