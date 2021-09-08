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
    public class VolunteersController : BaseController
    {
        private NgoEntity db = new NgoEntity();

        // GET: Admins/Volunteers
        public ActionResult Index(string search_name, int? page)
        {
            page = page ?? 1;
            int pagesize = 5;
            search_name = search_name ?? "";
            ViewBag.search_name = search_name;
            var volunteers = db.Volunteers.ToList().Where(x => x.VolunteersName.Contains(search_name));
            return View(volunteers.ToPagedList(page.Value, pagesize));
        }

        // GET: Admins/Volunteers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admins/Volunteers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VolunteersId,VolunteersName,Email,Address,Phone,Image,BirthDay,CreateDate,UpdatedDate,Status")] Volunteer volunteer, HttpPostedFileBase fileimage)
        {
            if (ModelState.IsValid)
            {
                if (fileimage != null)
                {
                    fileimage.SaveAs(Server.MapPath("~/Content/assets/images/team" + fileimage.FileName));
                    volunteer.Image = "/Content/assets/images/team" + fileimage.FileName;
                }
                db.Volunteers.Add(volunteer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(volunteer);
        }

        // GET: Admins/Volunteers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volunteer volunteer = db.Volunteers.Find(id);
            if (volunteer == null)
            {
                return HttpNotFound();
            }
            return View(volunteer);
        }

        // POST: Admins/Volunteers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VolunteersId,VolunteersName,Email,Address,Phone,Image,BirthDay,CreateDate,UpdatedDate,Status")] Volunteer volunteer, HttpPostedFileBase fileimage)
        {
            if (ModelState.IsValid)
            {
                    if (fileimage != null)
                    {
                        fileimage.SaveAs(Server.MapPath("~/Content/assets/images/team" + fileimage.FileName));
                        volunteer.Image = "/Content/assets/images/team" + fileimage.FileName;
                    }
                    db.Entry(volunteer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(volunteer);
        }

        // GET: Admins/Volunteers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volunteer volunteer = db.Volunteers.Find(id);
            if (volunteer == null)
            {
                return HttpNotFound();
            }
            db.Volunteers.Remove(volunteer);
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
