using Give_Aid.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Give_Aid.Controllers
{
    public class ImagesGalleryController : Controller
    {
        // GET: ImagesGallery
        public ActionResult Index()
        {
            var dao = new ImageGalleryDao();
            ViewBag.GetAll = dao.GetAll();
            return View();
        }

        public ActionResult ImagesDetail(int imgId)
        {
            var image = new ImageGalleryDao().ViewDetail(imgId);
            return View(image);
        }
        public JsonResult LoadImages(int id)
        {
            ImageGalleryDao dao = new ImageGalleryDao();
            var imgallery = dao.ViewDetail(id);
            var images = imgallery.MoreImage;
            if (images!= null)
            {
                XElement xImages = XElement.Parse(images);
                List<string> listImagesReturn = new List<string>();
                foreach (XElement element in xImages.Elements())
                {
                    listImagesReturn.Add(element.Value);
                }
                return Json(new
                {
                    data = listImagesReturn
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    
                }, JsonRequestBehavior.AllowGet);
            }
          
            
        }
    }
}