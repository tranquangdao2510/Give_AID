using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Give_Aid.Areas.Admins.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admins/Base
        public ActionResult Index()
        {
            return View();
        }
    }
}