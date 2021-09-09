using Give_Aid.Models.DAO;
using Give_Aid.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Give_Aid.Areas.Admins.Controllers
{
    public class OrganizationController : BaseController
    {
        // GET: Admins/Organization
        public ActionResult Index(int? page, string search_name)
        {
            page = page ?? 1;
            int pagesize = 3;
            var dao = new OrganizationDao();
            var model = dao.GetByName(search_name);
            return View(model.ToPagedList(page.Value,pagesize));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Organization organization)
        {
            if (ModelState.IsValid)
            {
                var dao = new OrganizationDao();
                int id = dao.Insert(organization);
                if (id > 0)
                {
                    SetAlert("Create organization success", "success");
                    return RedirectToAction("Index", "Organization");
                }
                else
                {
                    ModelState.AddModelError("", "error");
                }

            }
            return View(organization);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var Org = new OrganizationDao().Detail(id);
            return View(Org);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Organization organization)
        {

            if (ModelState.IsValid)
            {
                var dao = new OrganizationDao();
                var result = dao.Update(organization);
                if (result)
                {
                    SetAlert("Update organization success", "success");
                    return RedirectToAction("Index", "Organization");
                }
                else
                {
                    ModelState.AddModelError("", "error");
                }
            }

            return View("Index");
        }
     
  

        public ActionResult Delete(int id)
        {
          
            var dao = new OrganizationDao();
            var result = dao.Delete(id);
            if (result)
            {
                SetAlert("Delete organization success", "success");
                return RedirectToAction("Index", "Organization");
            }
            else
            {
                ModelState.AddModelError("", "error");
            }
            return RedirectToAction("Index");
        }
    }
}