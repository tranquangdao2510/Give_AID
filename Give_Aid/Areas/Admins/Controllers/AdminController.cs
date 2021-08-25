using Give_Aid.Common;
using Give_Aid.Models.DAO;
using Give_Aid.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Give_Aid.Areas.Admins.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admins/Admin
        public ActionResult Index(string searchString, int page =1, int pageSize=2)
        {
            var dao = new AdminDao();
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
        public ActionResult Create(Admin admin)
        {
            
                var dao = new AdminDao();
                var encryptedMd5Pas = Encryptor.MD5Hash(admin.PassWord);
                admin.PassWord = encryptedMd5Pas;
                int id = dao.Insert(admin);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "Them moi thanh cong");
                }
            
            return View("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var adm = new AdminDao().ViewDetail(id);
            return View(adm);
        }
        [HttpPost]
        public ActionResult Edit(Admin admin)
        {

            if (ModelState.IsValid)
            {
                var dao = new AdminDao();
                if (!string.IsNullOrEmpty(admin.PassWord))
                {
                    var encryptedMd5Pas = Encryptor.MD5Hash(admin.PassWord);
                    admin.PassWord = encryptedMd5Pas;
                }
                
                var result = dao.Update(admin);
                if (result)
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "Cap nhat thanh cong");
                }
            }

            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new AdminDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}