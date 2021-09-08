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
    public class FaqController : BaseController
    {
        // GET: Admins/Faq
        public ActionResult Index(int? page, string search_question)
        {
            page = page ?? 1;
            int pagesize = 3;
            var dao = new FaqDao();
            var model = dao.GetByQuestion(search_question);
            return View(model.ToPagedList(page.Value, pagesize));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Faq faq)
        {
            if (ModelState.IsValid)
            {
                var dao = new FaqDao();
                int id = dao.Insert(faq);
                if (id > 0)
                {
                    SetAlert("Create Faq success", "success");
                    return RedirectToAction("Index", "Faq");
                }
                else
                {
                    ModelState.AddModelError("", "error");
                }

                return View("Index");
            }
            return View(faq);

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var faq = new FaqDao().Detail(id);
            return View(faq);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Faq faq)
        {

            if (ModelState.IsValid)
            {
                var dao = new FaqDao();
                var result = dao.Update(faq);
                if (result)
                {
                    SetAlert("Update Faq success", "success");
                    return RedirectToAction("Index", "Faq");
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

            var dao = new FaqDao();
            var result = dao.Delete(id);
            if (result)
            {
                SetAlert("Delete Faq success", "success");
                return RedirectToAction("Index", "Faq");
            }
            else
            {
                ModelState.AddModelError("", "error");
            }
            return RedirectToAction("Index");
        }
    }
}