using Give_Aid.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        public ActionResult Index([Bind(Include = "IdMessage,Phone,Message,FirstName,LastName,Email,CreateDate")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Comtacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }
    }
}