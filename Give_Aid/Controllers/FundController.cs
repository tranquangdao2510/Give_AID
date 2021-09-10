using Give_Aid.Models.DAO;
using Give_Aid.Models.DataAccess;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Give_Aid.Controllers
{
    public class FundController : Controller
    {
        // GET: Fund
        private NgoEntity db = new NgoEntity();

        //public ActionResult Index(string search_title, string search_tag, int? page)
        //{
        //    page = page ?? 1;
        //    int pagesize = 6;
        //    search_title = search_title ?? "";
        //    search_tag = search_tag ?? "";
        //    var model = new BlogClientDao();
        //    model.Blogs = db.Blogs.ToList().Where(x => (x.Status == true) && (x.Title.Contains(search_title)) && (x.TagId.ToString().Contains(search_tag))).OrderBy(x => x.BlogId).ToPagedList(page.Value, pagesize);
        //    model.BlogsPagination = db.Blogs.ToList();
        //    model.BlogsNewpost = db.Blogs.Where(x => x.Status == true).OrderByDescending(x => x.CreateDate).Take(2).ToList();
        //    model.Tags = db.Tags.ToList().Where(x => x.Status == true);
        //    return View(model);
        //}

        public ActionResult Index()
        {
            var dao = new FundDao();
            ViewBag.Get = dao.ListAllFund();
            ViewBag.Featured = dao.FundFeatured(1);
            return View();
        }

        public ActionResult FundDetail(string id)
        {
            var model = new FundDao();
            ViewBag.GetDetail = model.Detail(id);
            ViewBag.Featured = model.newFund(3);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            return View(model);
        }
        public JsonResult ListFundName(string name)
        {
            var data = new FundDao().ListFundName(name);
            return Json(new
            {
                data = data,
                status= true
            },JsonRequestBehavior.AllowGet);
        }
        public ActionResult Search(string keyword)
        {
            return View();
        }

    }
}