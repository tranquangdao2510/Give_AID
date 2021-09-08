using Give_Aid.Models.DAO;
using Give_Aid.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Give_Aid.Areas.Admins.Controllers
{
    public class DonateController : Controller
    {
        // GET: Admins/Donate
        public ActionResult Index(string searchString, int page = 1, int pageSize = 7)
        {
            var dao = new DonateDao();
            var model = dao.GetAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBagCate();
            return View();
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {

            var result = new DonateDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }

        [HttpGet]
        public JsonResult Detail(int id)
        {
            var dao = new DonateDao();
            var donate = dao.ViewDetail(id);
            return Json(new
            {
                data = donate,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(Donate donate)
        {

            SetViewBagCate(donate.PaymentId);
            return View();
        }


        public void SetViewBagCate(int? selectedId= null)
        {
            var dao = new PaymentDao();
            ViewBag.PaymentID = new SelectList(dao.ListPayment(), "PaymentId", "PaymentName", selectedId);
        }


    }
}