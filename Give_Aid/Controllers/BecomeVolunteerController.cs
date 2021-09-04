using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Give_Aid.Models.DAO;
using Give_Aid.Models.DataAccess;

namespace Give_Aid.Controllers
{
    public class BecomeVolunteerController : Controller
    {
        NgoEntity db = new NgoEntity();
        // GET: BecomeVolunteer
        public ActionResult Index()
        {
            var model = new BecomVolunteerDao();
            model.GetContacts = db.Comtacts.ToList().Where(x => x.Status == true).Take(1);
            model.GetPartners = db.Partners.ToList().Where(x => x.Status == true);
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(string FullName, string RefrenceContact, string Email, string Phone, string Message)
        {
            string subject = "Application to join volunteers website NGO";
            string body = "Full Name:" + FullName + ";  \nPhone:" + Phone + ";  \nRefrence Contact:" + RefrenceContact + ";  \nMessage:" + Message + ";  \n From:\n" + Email;
            WebMail.Send("eprojectsemiii@gmail.com", subject, body, null, null, null, true, null, null, null, null, null, null);
            ViewBag.msg = "Thanks for emailing us...";
            var model = new BecomVolunteerDao();
            model.GetContacts = db.Comtacts.ToList().Where(x => x.Status == true).Take(1);
            model.GetPartners = db.Partners.ToList().Where(x => x.Status == true);
            return View(model);
        }

    }
}