using Give_Aid.Models.DAO;
using Give_Aid.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Give_Aid.Areas.Admins.Controllers
{
    public class CategoriesController : BaseController
    {// GET: Admins/Categories
        public ActionResult Index()
        {
            var dao = new CategoryDao();
            var model = dao.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category cate)
        {

            var dao = new CategoryDao();
            int id = dao.Insert(cate);
            if (id > 0)
            {
                SetAlert("Create Category success", "success");
                return RedirectToAction("Index", "Categories");
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
            var cate = new CategoryDao().Detail(id);
            return View(cate);
        }
        [HttpPost]
        public ActionResult Edit(Category cate)
        {

            if (ModelState.IsValid)
            {
                var dao = new CategoryDao();
                var result = dao.Update(cate);
                if (result)
                {
                    SetAlert("Update Category success", "success");
                    return RedirectToAction("Index", "Categories");
                }
                else
                {
                    ModelState.AddModelError("", "error");
                }
            }

            return View("Index");
        }
    }
}