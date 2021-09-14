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
    public class AdminController : BaseController
    {
        // GET: Admins/Admin
        [HasPermission(RoleId = "VIEW")]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 7)
        {
            var dao = new AdminDao();
            var model = dao.GetAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        [HasPermission(RoleId = "CREATE")]
        public ActionResult Create()
        {
            SetviewBag();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Admin admin)
        {

            if (ModelState.IsValid)
            {
                var dao = new AdminDao();
                var encryptedMd5Pas = Encryptor.MD5Hash(admin.PassWord);
                admin.PassWord = encryptedMd5Pas;
                int id = dao.Insert(admin);
                if (id > 0)
                {
                    SetAlert("Create Admin success", "success");
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "error");
                }
                return View("Index");
            }
            SetviewBag();
            return View(admin);
        }
        [HttpGet]
        [HasPermission(RoleId = "EDIT")]
        public ActionResult Edit(int id)
        {
            SetviewBag();
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
                    SetAlert("Update Admin success", "success");
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "error");
                }
                return View("Index");
            }
            SetviewBag();
            return View(admin);
            
        }
        [HttpDelete]
        [HasPermission(RoleId = "DELETE")]
        public ActionResult Delete(int id)
        {
            var dao = new AdminDao();
            var result = dao.Delete(id);
            if (result)
            {
                SetAlert("Delete Admin success", "success");
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                SetAlert("Unable to delete admin with data", "error");
            }
            return RedirectToAction("Index");
        }
        public void SetviewBag(string SelectedId = null)
        {
            var groupAdminDao = new GroupAdminDao();
           
            ViewBag.GroupAdminId = new SelectList(groupAdminDao.GetAll(), "Id", "Name", SelectedId);
        }
    }
}