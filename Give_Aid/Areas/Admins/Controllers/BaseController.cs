using Give_Aid.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Give_Aid.Areas.Admins.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var session = (AdminLogin)Session[CommonAdmin.ADMIN_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Login", action = "Index", Areas = "Admins" })
                    );
            }
            base.OnActionExecuted(filterContext);
        }
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