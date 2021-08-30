using Give_Aid.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Give_Aid.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var funddao = new FundDao();
            ViewBag.TopFund = funddao.ListtopFund(4);
            ViewBag.AllFund = funddao.ListAllFund();

            var blogdao = new BlogClientDao();
            ViewBag.AllBlog = blogdao.GetBlog();

            var partnertdao = new PartnerDao();
            ViewBag.AllPartner = partnertdao.GetPartner();

            var voluteerdao = new VolunteerDao();
            ViewBag.AllVolunteer =voluteerdao.GetVolunteer();


            return View();
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Causes()
        {

            return View();
        }
        public ActionResult CausesDetail()
        {

            return View();
        }
        public ActionResult OurFaq()
        {

            return View();
        }
        public ActionResult Volunteerss()
        {

            return View();
        }
        public ActionResult BecomeVolunteerss()
        {

            return View();
        }
        public ActionResult Event()
        {

            return View();
        }
        public ActionResult EventDetail()
        {

            return View();
        }
        public ActionResult Blog()
        {

            return View();
        }
        public ActionResult BlogDetail()
        {

            return View();
        }
        public ActionResult Donate()
        {

            return View();
        }

        [ChildActionOnly]
        public ActionResult Sliders()
        {
            var model = new SliderDao().ListAll();
            return PartialView(model);
        }
    }
}