using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Give_Aid.Areas.Admin.Controllers
{
    public class AdminsController : Controller
    {
        // GET: Admin/Admins
        public ActionResult Index()
        {
            return View();
        }

    }
}