using Give_Aid.Common;
using Give_Aid.Models.DAO;
using Give_Aid.Models.DataAccess;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Give_Aid.Areas.Admins.Controllers
{
    public class AboutController : BaseController
    {
        // GET: Admins/About

        [HasPermission(RoleId = "VIEW")]
        public ActionResult Index(int? page, string search_title)
        {
            page = page ?? 1;
            int pagesize = 5;
            var dao = new AboutDao();
            var model = dao.GetByName(search_title);
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
        public ActionResult Create(About about)
        {
            if (ModelState.IsValid) 
            {
                var dao = new AboutDao();
                int id = dao.Insert(about);
                if (id > 0)
                {
                    SetAlert("Create About success", "success");
                    return RedirectToAction("Index", "About");
                }
                else
                {
                    ModelState.AddModelError("", "error");
                }

                return View("Index");
            }
            return View(about);
        }
        [HttpGet]

        [HasPermission(RoleId = "DETAIL")]
        public ActionResult Detail(int id)
        {
            var about = new AboutDao().Detail(id);
            return View(about);
        }

        [HttpGet]

        [HasPermission(RoleId = "EDIT")]
        public ActionResult Edit(int id)
        {
            var about = new AboutDao().Detail(id);
            return View(about);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(About about)
        {

            if (ModelState.IsValid)
            {
                var dao = new AboutDao();
                var result = dao.Update(about);
                if (result)
                {
                    SetAlert("Update About success", "success");
                    return RedirectToAction("Index", "About");
                }
                else
                {
                    ModelState.AddModelError("", "error");
                }
            }

            return View("Index");
        }
        [HasPermission(RoleId = "DELETE")]
        public ActionResult Delete(int id)
        {

            var dao = new AboutDao();
            var result = dao.Delete(id);
            if (result)
            {
                SetAlert("Delete About success", "success");
                return RedirectToAction("Index", "About");
            }
            else
            {
                ModelState.AddModelError("", "error");
            }
            return RedirectToAction("Index");
        }
    }
}