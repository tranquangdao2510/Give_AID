using Give_Aid.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Give_Aid.Controllers
{
    public class DonateController : Controller
    {
        // GET: Donate
        public ActionResult DonateList()
        {
            SetViewBag();
            return View();
        }

        public void SetViewBag(int? selectedId =null)
        {
            var fundDao = new FundDao();
            var paymentDao = new PaymentDao();

            ViewBag.FundId = new SelectList(fundDao.ListAllFund(), "FundId", "FundName", selectedId);
            ViewBag.PaymentId = new SelectList(paymentDao.ListPayment(), "PaymentId", "PaymentName", selectedId);

        }


    }
}