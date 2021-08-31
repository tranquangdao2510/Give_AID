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
        public ActionResult Index(string search_title, string search_tag, int? page)
        {
            page = page ?? 1;
            int pagesize = 6;
            search_title = search_title ?? "";
            search_tag = search_tag ?? "";
            var model = new BlogClientDao();
            model.Blogs = db.Blogs.ToList().Where(x => (x.Status==true)&&(x.Title.Contains(search_title)) && (x.TagId.ToString().Contains(search_tag))).OrderBy(x => x.BlogId).ToPagedList(page.Value, pagesize);
            model.BlogsPagination = db.Blogs.ToList();
            model.BlogsNewpost = db.Blogs.Where(x => x.Status == true).OrderByDescending(x => x.CreateDate).Take(2).ToList();
            model.Tags = db.Tags.ToList().Where(x=>x.Status==true);
            return View(model);
        }

        public ActionResult BlogDetail(string search_title, string search_tag, int? id)
        {
            search_title = search_title ?? "";
            search_tag = search_tag ?? "";
            var model = new BlogClientDao();
            model.Blogs = db.Blogs.ToList().Where(x => (x.BlogId.Equals(id)) && (x.Title.Contains(search_title)) && (x.TagId.ToString().Contains(search_tag)));
            model.BlogsNewpost = db.Blogs.Where(x => x.Status == true).OrderByDescending(x => x.CreateDate).Take(2).ToList();
            model.Tags = db.Tags.ToList().Where(x => x.Status == true);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (model.Blogs == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
    }
}