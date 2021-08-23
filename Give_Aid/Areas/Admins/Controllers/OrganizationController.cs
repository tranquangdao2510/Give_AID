using Give_Aid.Models.DAO;
using Give_Aid.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Give_Aid.Areas.Admins.Controllers
{
    public class OrganizationController : BaseController
    {
        // GET: Admins/Organization
        public ActionResult Index()
        {
            var dao = new OrganizationDao();
            var model = dao.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Organization organization)
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

            return View("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var Org = new OrganizationDao().Detail(id);
            return View(Org);
        }
        [HttpPost]
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
    }
}