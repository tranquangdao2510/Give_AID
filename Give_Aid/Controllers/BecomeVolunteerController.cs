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
        [ValidateAntiForgeryToken]
        public ActionResult Index(string FullName, string RefrenceContact, string Email, string Phone, string Message, string Address, DateTime BirthDay, HttpPostedFileBase fileimage)
        {
            Volunteer volunteer = new Volunteer();
            if (db.Volunteers.Any(x => x.Email.Equals(Email)))
            {
                ViewBag.validate = "This email has been sent";
            }
            else
            {
                if (fileimage != null)
                {
                    fileimage.SaveAs(Server.MapPath("~/Content/assets/images/team" + fileimage.FileName));
                    volunteer.Image = "/Content/assets/images/team" + fileimage.FileName;
                    volunteer.VolunteersName = FullName;
                    volunteer.Email = Email;
                    volunteer.Address = Address;
                    volunteer.Phone = Phone;
                    volunteer.BirthDay = BirthDay;
                    volunteer.Status = false;
                    db.Volunteers.Add(volunteer);
                    db.SaveChanges();
                    ViewBag.msg = "Thanks for emailing us...";
                }
                else
                {
                    ViewBag.valiimg = "Image cannot be empty";
                }
            }
            string subject = "Application to join volunteers website NGO";
            string body = "Full Name:" + FullName + ";  \nPhone:" + Phone + ";  \nRefrence Contact:" + RefrenceContact + ";  \nMessage:" + Message + ";  \n From:\n" + Email;
            WebMail.Send("eprojectsemiii@gmail.com", subject, body, null, null, null, true, null, null, null, null, null, null);
            var model = new BecomVolunteerDao();
            model.GetContacts = db.Comtacts.ToList().Where(x => x.Status == true).Take(1);
            model.GetPartners = db.Partners.ToList().Where(x => x.Status == true);
            return View(model);
        }

    }
}