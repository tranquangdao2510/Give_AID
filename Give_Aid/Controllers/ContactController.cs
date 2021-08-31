using Give_Aid.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Give_Aid.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        private NgoEntity db = new NgoEntity();
        public ActionResult Index()
        {
            return View(db.Comtacts.ToList().Where(x=>x.Status==true).Take(1));
        }
        [HttpPost]
        public ActionResult Index(string firstName, string lastName, string email, string phone, string message)
        {
            string subject = "Gmail sent from website NGO";
            string body = "First Name:" + firstName + ";  \nLast Name:" + lastName + ";  \nPhone:" + phone + ";  \nMessage:" + message + ";  \n From:\n" + email;
            WebMail.Send("eprojectsemiii@gmail.com", subject, body, null, null, null, true, null, null, null, null, null, null);
            ViewBag.msg = "Email sent successfully...";
            return View();
        }
    }
}