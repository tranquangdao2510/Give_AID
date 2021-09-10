using Give_Aid.Models.DAO;
using Give_Aid.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml.Linq;

namespace Give_Aid.Areas.Admins.Controllers
{
    public class ImageGalleryController : BaseController
    {
        // GET: Admins/ImageGallery
        public ActionResult Index(string searchString, int page = 1, int pageSize = 7)
        {
            var dao = new ImageGalleryDao();
            var model = dao.GetAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetviewBag();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ImageGallery entity)
        {
            if (ModelState.IsValid)
            {
                var dao = new ImageGalleryDao();
                int id = dao.Insert(entity);
                if (id > 0)
                {
                    SetAlert("Create ImageGallery success", "success");
                    return RedirectToAction("Index", "ImageGallery");
                }
                else
                {
                    ModelState.AddModelError("", "error");
                }
                return View("Index");
            }
            SetviewBag();
            return View(entity);
            
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            SetviewBag();
            var imageGall = new ImageGalleryDao().ViewDetail(id);
            return View(imageGall);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ImageGallery imageGallery)
        {

            if (ModelState.IsValid)
            {
                var dao = new ImageGalleryDao();

                var result = dao.Update(imageGallery);
                if (result)
                {
                    SetAlert("Update ImageGallery success", "success");
                    return RedirectToAction("Index", "ImageGallery");
                }
                else
                {
                    ModelState.AddModelError("", "error");
                }
                return View("Index");
            }

            SetviewBag();
            return View(imageGallery);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var dao = new ImageGalleryDao();
            var result = dao.Delete(id);
            if (result)
            {
                SetAlert("Delete ImageGallery success", "success");
                return RedirectToAction("Index", "ImageGallery");
            }
            else
            {
                ModelState.AddModelError("", "error");
            }
            return RedirectToAction("Index");
        }
        public void SetviewBag(string SelectedId = null)
        {
            var tagdao = new TagsDao();
          
            ViewBag.TagId = new SelectList(tagdao.GetAll(), "TagId", "TagName", SelectedId);
        }
        [HttpPost]
        public JsonResult SaveImages(int id,string images)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var listImages  = serializer.Deserialize<List<string>>(images);

            XElement xElement = new XElement("Images");
            foreach (var item in listImages)
            {
                var subtring = item.Substring(22);
                xElement.Add(new XElement("Image", subtring));
            }
            ImageGalleryDao dao = new ImageGalleryDao();
           
            try
            {
                dao.UpdateImages(id, xElement.ToString());
                return Json(new
                {
                    status = true
                });
            }
            catch (Exception)
            {

                return Json(new
                {
                    status = false
                });
            }
           
        }

        public JsonResult LoadImages(int id)
        {
            ImageGalleryDao dao = new ImageGalleryDao();
            var imgallery = dao.ViewDetail(id);
            var images = imgallery.MoreImage;
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
    }
}