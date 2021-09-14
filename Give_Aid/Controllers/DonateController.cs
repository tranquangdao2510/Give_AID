using Give_Aid.Models.DAO;
using Give_Aid.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
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
        [ValidateAntiForgeryToken]
        public ActionResult DonateList(Donate entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dao = new DonateDao();
                    var session = Session[Give_Aid.Common.CommonConstants.USER_SESSION] as Give_Aid.Common.CustomerLogin;
                    entity.CustomerId = session.CustomerId;
                    entity.Status = false;
                    int id = dao.Insert(entity);

                    // send mail
                    string name = session.CustomerName;
                    string phone = session.Phone;
                    string address = session.Address;
                    string email = session.Email;
                    var total = entity.Amount;
                    string subject = "New donate customers";
                    string conten = System.IO.File.ReadAllText(Server.MapPath("~/Views/Donate/newDonate.html"));
                    conten = conten.Replace("{{CustomerName}}", name);
                    conten = conten.Replace("{{Phone}}", phone);
                    conten = conten.Replace("{{Address}}", address);
                    conten = conten.Replace("{{Email}}", email);
                    conten = conten.Replace("{{Amount}}", total.ToString());
                    WebMail.Send("giveaidprojectsem3@gmail.com", subject, conten, null, null, null, true, null, null, null, null, null, null);

                    if (id != null)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "error");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
           
            SetViewBag();
           
            return View(entity);


        }
    }
}