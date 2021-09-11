using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Give_Aid
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*botdetect}",
             new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            // search
            routes.MapRoute(
               name: "Search",
               url: "search",
               defaults: new { controller = "Fund", action = "Search", id = UrlParameter.Optional },
               new[] { "Give_Aid.Controllers" }
           );

            
            //routes.MapRoute(
            //    name: "Fund Detail",
            //    url: "Detail/{Metatitle}/{id}",
            //    defaults: new { controller = "Fund", action = "FundDetail", id = UrlParameter.Optional },
            //    new[] { "Give_Aid.Controllers" }
            //);
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "Give_Aid.Controllers" }
            );
        }
    }
}
