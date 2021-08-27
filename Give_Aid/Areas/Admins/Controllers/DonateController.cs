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
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBagCate();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Donate donate)
        {

            SetViewBagCate();
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new DonateDao();
            var donate = dao.ViewDetail(id);
            SetViewBagCate(donate.PaymentId);
            return View();
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