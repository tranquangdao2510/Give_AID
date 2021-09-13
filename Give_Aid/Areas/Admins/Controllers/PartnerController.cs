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
    public class PartnerController : BaseController
    {
        // GET: Admins/Partner
        [HasPermission(RoleId = "VIEW")]
        public ActionResult Index(int? page, string search_name)
        {
            page = page ?? 1;
            int pagesize = 3;
            var dao = new PartnerDao();
            var model = dao.GetAll(search_name);
            return View(model.ToPagedList(page.Value, pagesize));
        }
        [HttpGet]

        [HasPermission(RoleId = "CREATE")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Partner partner)
        {
            if (ModelState.IsValid)
            {
                var dao = new PartnerDao();

                int id = dao.Insert(partner);
                if (id > 0)
                {
                    SetAlert("Create Partner success", "success");
                    return RedirectToAction("Index", "Partner");

                }
                else
                {
                    ModelState.AddModelError("", "error");

                }
                return View("Index");
            }
            return View(partner);
        }
        [HttpGet]
        [HasPermission(RoleId = "EDIT")]
        public ActionResult Edit(int id)
        {
            var partner = new PartnerDao().Detail(id);
            return View(partner);
        }
        [HttpPost]
        public ActionResult Edit(Partner partner)
        {

            if (ModelState.IsValid)
            {
                var dao = new PartnerDao();
                var result = dao.Update(partner);
                if (result)
                {
                    SetAlert("Update Fund success", "success");
                    return RedirectToAction("Index", "Partner");
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

            var dao = new PartnerDao();
            var result = dao.Delete(id);
            if (result)
            {
                SetAlert("Delete Fund success", "success");
                return RedirectToAction("Index", "Fund");
            }
            else
            {
                ModelState.AddModelError("", "error");
            }
            return RedirectToAction("Index");
        }
    }
}