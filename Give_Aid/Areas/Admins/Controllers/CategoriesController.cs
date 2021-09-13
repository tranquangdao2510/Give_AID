using Give_Aid.Models.DAO;
using Give_Aid.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Give_Aid.Common;

namespace Give_Aid.Areas.Admins.Controllers
{
    public class CategoriesController : BaseController
    {// GET: Admins/Categories
        public ActionResult Index(int? page, string search_name)
        {
            page = page ?? 1;
            int pagesize = 3;
            var dao = new CategoryDao();
            var model = dao.GetByName(search_name);
            return View(model.ToPagedList(page.Value, pagesize));
        }

        [HttpGet]

        [HasPermission(RoleId = "CREATE")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category cate)
        {
            if (ModelState.IsValid) 
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
            return View(cate);
            
        }

        [HttpGet]

        [HasPermission(RoleId = "EDIT")]
        public ActionResult Edit(int id)
        {
            var cate = new CategoryDao().Detail(id);
            return View(cate);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
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

            return View(cate);
        }

        [HasPermission(RoleId = "DELETE")]
        public ActionResult Delete(int id)
        {

            
                if (ModelState.IsValid)
                {
                    var dao = new CategoryDao();
                    var result = dao.Delete(id);
                    if (result)
                    {
                        SetAlert("Delete Categories success", "success");
                        return RedirectToAction("Index", "Categories");
                    }
                    else
                    {
                        SetAlert("Unable to delete category with data", "error");
                    }
                }
            
            return RedirectToAction("Index");
        }
    }
}