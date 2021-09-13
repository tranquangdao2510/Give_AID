using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Give_Aid.Common;
using Give_Aid.Models.DataAccess;
using PagedList;

namespace Give_Aid.Areas.Admins.Controllers
{
    public class ContactsController : BaseController
    {
        private NgoEntity db = new NgoEntity();

        // GET: Admins/Contacts

        [HasPermission(RoleId = "VIEW")]
        public ActionResult Index(string search_email, int? page)
        {
            page = page ?? 1;
            int pagesize = 5;
            search_email = search_email ?? "";
            ViewBag.search_name = search_email;
            var contacts = db.Comtacts.ToList().Where(x => x.Email.Contains(search_email));
            return View(contacts.ToPagedList(page.Value, pagesize));
        }

        // GET: Admins/Contacts/Create

        [HasPermission(RoleId = "CREATE")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admins/Contacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMessage,Phone,Address,Email,CreateDate,UpdateDate,Status")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Comtacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        // GET: Admins/Contacts/Edit/5

        [HasPermission(RoleId = "EDIT")]
        public ActionResult Edit(int? id)
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
            return View(contact);
        }

        // POST: Admins/Contacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMessage,Phone,Address,Email,CreateDate,UpdateDate,Status")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // GET: Admins/Contacts/Delete/5

        [HasPermission(RoleId = "DELETE")]
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
