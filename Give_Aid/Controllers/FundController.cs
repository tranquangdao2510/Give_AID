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

  

        public ActionResult Index(int? page,string search_name)
        {
            page = page ?? 1;
            int pagesize = 6;
            var dao = new FundDao();
            ViewBag.Get = dao.GetAll(search_name).ToPagedList(page.Value,pagesize);
            ViewBag.Featured = dao.FundFeatured(1);
            return View();
        }

        public ActionResult FundDetail(string id)
        {
            var model = new FundDao();
            ViewBag.GetDetail = model.Detail(id);
            ViewBag.Featured = model.newFund(3);
            ViewBag.GetDonate = model.GetDonate(2);
            SetViewBag();
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
        public void SetViewBag(int? selectedId = null)
        {
            var customerdao = new CustomerDao();

            ViewBag.CustomerId = new SelectList(customerdao.GetAll(), "CustomerId", "CustomerName", selectedId);

        }

    }
}