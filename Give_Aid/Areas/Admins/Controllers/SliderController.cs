using Give_Aid.Models.DAO;
using Give_Aid.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Give_Aid.Areas.Admins.Controllers
{
    public class SliderController : BaseController
    {
        // GET: Admins/Slider
        public ActionResult Index(string searchString, int page = 1, int pageSize = 7)
        {
            var dao = new SliderDao();
            var model = dao.GetAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        //[ValidateInput(false)]
        public ActionResult Create(Slide slide)
        {
            var dao = new SliderDao();
            int id = dao.Insert(slide);
            if (id > 0)
            {
                SetAlert("Create Slider success", "success");
                return RedirectToAction("Index", "Slider");
            }
            else
            {
                ModelState.AddModelError("", "error");
            }

            return View("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var slider = new SliderDao().ViewDetail(id);
            return View(slider);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Slide slide)
        {

            if (ModelState.IsValid)
            {
                var dao = new SliderDao();
                
                var result = dao.Update(slide);
                if (result)
                {
                    SetAlert("Update Slider success", "success");
                    return RedirectToAction("Index", "Slider");
                }
                else
                {
                    ModelState.AddModelError("", "error");
                }
            }

            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var dao = new SliderDao();
            var result = dao.Delete(id);
            if (result)
            {
                SetAlert("Delete Slider success", "success");
                return RedirectToAction("Index", "Slider");
            }
            else
            {
                ModelState.AddModelError("", "error");
            }
            return RedirectToAction("Index");
        }
    }
}