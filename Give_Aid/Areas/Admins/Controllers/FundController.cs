using Give_Aid.Models.DAO;
using Give_Aid.Models.DataAccess;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Give_Aid.Areas.Admins.Controllers
{
    public class FundController : BaseController
    {
        // GET: Admins/Fund
        public ActionResult Index(int? page, string search_name)
        {
            page = page ?? 1;
            int pagesize = 3;
            var dao = new FundDao();
            var model = dao.GetAll(search_name);
            return View(model.ToPagedList(page.Value, pagesize));
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            SetviewBag();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Fund fund)
        {
            var dao = new FundDao();
            int id = dao.Insert(fund);
            if (id > 0)
            {
                SetAlert("Create Fund success", "success");
                return RedirectToAction("Index", "Fund");

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
            var fund = new FundDao().Detail(id);
            SetviewBag();
            return View(fund);
        }
        [HttpPost]
        public ActionResult Edit(Fund fund)
        {

            if (ModelState.IsValid)
            {
                var dao = new FundDao();
                var result = dao.Update(fund);
                if (result)
                {
                    SetAlert("Update Fund success", "success");
                    return RedirectToAction("Index", "Fund");
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

            var dao = new FundDao();
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
        public void SetviewBag(string SelectedId = null)
        {
            var catedao = new CategoryDao();
            var orgdao = new OrganizationDao();
            ViewBag.CategoryId = new SelectList(catedao.GetAll(), "CategoryId", "CategoryName", SelectedId);
            ViewBag.OrganizationId = new SelectList(orgdao.GetAll(), "OrganizationId", "OrganizationName", SelectedId);
        }
    }
}