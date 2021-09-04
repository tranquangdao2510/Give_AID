using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Give_Aid.Models.DataAccess;
using Give_Aid.Models.DAO;
using System.Web.Helpers;

namespace Give_Aid.Controllers
{
    public class FaqController : Controller
    {
        NgoEntity db = new NgoEntity();
        // GET: Faq
        public ActionResult Index()
        {
            var model = new FaqClientDao();
            model.GetFaqs = db.Faqs.ToList().Where(x => x.Status == true).Take(8).OrderByDescending(x=>x.CreateDate);
            model.GetPartners = db.Partners.ToList().Where(x => x.Status == true);
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(string FullName,string Email,string Question)
        {
            string subject = "Question from NGO website";
            string body = "Full Name:" + FullName + "\nQuestion:" + Question + ";  \n From:\n" + Email;
            WebMail.Send("eprojectsemiii@gmail.com", subject, body, null, null, null, true, null, null, null, null, null, null);
            ViewBag.msg = "Question has been submitted...";
            var model = new FaqClientDao();
            model.GetFaqs = db.Faqs.ToList().Where(x => x.Status == true).Take(8).OrderByDescending(x => x.CreateDate);
            model.GetPartners = db.Partners.ToList().Where(x => x.Status == true);
            return View(model);
        }
    }
}