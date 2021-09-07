using Give_Aid.Models.DAO;
using Give_Aid.Models.DataAccess;
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
        [HttpGet]
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
        [HttpPost]
        public ActionResult DonateList(Donate entity)
        {
            var session = Session[Give_Aid.Common.CommonConstants.USER_SESSION] as Give_Aid.Common.CustomerLogin;
            var dao = new DonateDao();
            entity.CustomerId = session.CustomerId;
            entity.Status = false;
            dao.Insert(entity);

           // var funddao = new FundDao();
           // var fund = new Fund();
           //var fundamount= funddao.Detail(entity.FundId);
           // fundamount.CurentAmount += entity.Amount;
           // funddao.UpdateAmount(fundamount);
            return RedirectToAction("Index","Home");


        }
    }
}