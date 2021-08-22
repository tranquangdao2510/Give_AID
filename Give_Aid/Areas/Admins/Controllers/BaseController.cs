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
<<<<<<< HEAD
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var session = (AdminLogin)Session[CommonConstants.USER_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Login", action = "Index", Areas = "Admins" })
                    );
            }
            base.OnActionExecuted(filterContext);
=======
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
>>>>>>> 4d3c8524f8a9b6630a72b0785d0d99e387a32b4d
        }
    }
}