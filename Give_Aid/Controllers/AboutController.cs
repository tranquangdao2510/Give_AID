using Give_Aid.Models.DAO;
using Give_Aid.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Give_Aid.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        private NgoEntity db = new NgoEntity();

        public ActionResult Index()
        {
            var dao = new AboutDao();
            ViewBag.Get = dao.GetAll();
            ViewBag.GetVolunteer = dao.GetVolunteer();
            ViewBag.GetFaq = dao.GetFaq(3);
            ViewBag.GetPartner = dao.GetPartner();
            return View();
        }
    }
}