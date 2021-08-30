using Give_Aid.Models.DataAccess;
using Give_Aid.Models.DAO;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Give_Aid.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        private NgoEntity db = new NgoEntity();
        public ActionResult Index( string search_title, string search_tag)
        {
            search_title = search_title ?? "";
            search_tag = search_tag ?? "";
            var model = new BlogClientDao();
            model.Blogs = db.Blogs.ToList().Where(x =>(x.Title.Contains(search_title))&&(x.TagId.ToString().Contains(search_tag))).OrderBy(x => x.BlogId);
            model.BlogsNewpost = db.Blogs.OrderByDescending(x => x.CreateDate).Take(2).ToList();
            model.Tags = db.Tags.ToList();
            return View(model);
        }
        public ActionResult BlogDetail(int? id)
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
    }
}