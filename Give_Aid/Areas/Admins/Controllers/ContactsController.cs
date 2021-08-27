using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Give_Aid.Models.DataAccess;
using PagedList;

namespace Give_Aid.Areas.Admins.Controllers
{
    public class ContactsController : Controller
    {
        private NgoEntity db = new NgoEntity();

        // GET: Admins/Contacts
        public ActionResult Index(int? page)
        {
            page = page ?? 1;
            int pagesize = 5;
            var contacts = db.Comtacts.ToList();
            return View(contacts.ToPagedList(page.Value, pagesize));
        }


        // GET: Admins/Contacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Comtacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            db.Comtacts.Remove(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
