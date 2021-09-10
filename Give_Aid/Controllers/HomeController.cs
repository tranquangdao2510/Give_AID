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

            var voluteerdao = new VolunteerDao();
            ViewBag.AllVolunteer =voluteerdao.GetVolunteer();

            var imageGallerydao = new ImageGalleryDao();
            ViewBag.AllImageGallery = imageGallerydao.GetImageGallery();


            return View();
        }
        

        [ChildActionOnly]
        public ActionResult Sliders()
        {
            var model = new SliderDao().ListAll();
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult Partners()
        {
            var model = new PartnerDao().GetPartner();
            return PartialView(model);
        }
    }
}