using Give_Aid.Areas.Admins.Models;
using Give_Aid.Common;
using Give_Aid.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Give_Aid.Areas.Admins.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admins/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new AdminDao();
                var result = dao.Login(model.AdminName, Encryptor.MD5Hash(model.Password));
                if (result == Convert.ToBoolean(1))
                {
                    var user = dao.GetbyId(model.AdminName);
                    var userSession = new AdminLogin();
                    userSession.AdminName = user.AdminName;
                    userSession.AdminId = user.AdminId;

                    Session.Add(CommonAdmin.ADMIN_SESSION, userSession);
                    return RedirectToAction("Dashboard", "Home");
                }
                else if (result == Convert.ToBoolean(0))
                {
                    ModelState.AddModelError("", "tai khoan ko ton tai");
                }
                else if (result == Convert.ToBoolean(-1))
                {
                    ModelState.AddModelError("", "tai khoan dang bi khoa");
                }
                else if (result == Convert.ToBoolean(-2))
                {
                    ModelState.AddModelError("", "mat khau ko dung");
                }
                else
                {
                    ModelState.AddModelError("", "Vui long kiem tra tk mk");
                }
            }
            return View("Index");
        }
    }
}