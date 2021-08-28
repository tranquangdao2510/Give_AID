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
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "IdMessage,Phone,Message,FirstName,LastName,Email,CreateDate")] Contact contact, string firstName, string lastName, string email, string phone, string message)
        {
            if (ModelState.IsValid)
            {
                string subject = "Gmail sent from website NGO";
                string body ="First Name:"+ firstName +";  Last Name:"+ lastName+";  Phone:" + phone +";  Message:"+ message;
                WebMail.Send(email, subject, body, null, null, null, true, null, null, null, null, null, null);
                db.Comtacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }
    }
}