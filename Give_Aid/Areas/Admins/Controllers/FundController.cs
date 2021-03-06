using Give_Aid.Models.DAO;
using Give_Aid.Models.DataAccess;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System;

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
        [ValidateAntiForgeryToken]
        [HandleError]
        public ActionResult Create(Fund fund)
        {
         
                if (ModelState.IsValid)
                {
                    try
                    {
                        var dao = new FundDao();
                        string id = dao.Insert(fund);
                        if (id != null)
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
                    catch (Exception ex)
                    {
                      ex.Message.Contains(ViewBag.error = "id already exists");
                    }
                }
            
            
            SetviewBag();
            return View(fund);
        }
        [HttpGet]
        public ActionResult Detail (string id)
        {
            var getDetail = new FundDao().Detail(id);
            SetviewBag();
            return View(getDetail);
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            var fund = new FundDao().Detail(id);
            SetviewBag();
            return View(fund);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
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
            SetviewBag();
            return View("Index");
        }
        public ActionResult Delete(string id)
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