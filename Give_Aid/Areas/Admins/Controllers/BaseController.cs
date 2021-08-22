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
       
        protected void SetAlert(String message, string type)
        {
            TempData["AlertMessage"] = message;
            if(type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
    }
}