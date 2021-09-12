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
            // home
            routes.MapRoute(
                name: "Fund Detail",
                url: "Detail/{Metatitle}/{id}",
                defaults: new { controller = "Fund", action = "FundDetail", id = UrlParameter.Optional },
                new[] { "Give_Aid.Controllers" }
            );
            // fund
            routes.MapRoute(
                name: "Fund",
                url: "Fund",
                defaults: new { controller = "Fund", action = "Index", id = UrlParameter.Optional },
                new[] { "Give_Aid.Controllers" }
            );
            // about
            routes.MapRoute(
                name: "About us",
                url: "About",
                defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional },
                new[] { "Give_Aid.Controllers" }
            );
            // Volunteer
            routes.MapRoute(
                name: "Volunteer",
                url: "Volunteer",
                defaults: new { controller = "Volunteer", action = "Index", id = UrlParameter.Optional },
                new[] { "Give_Aid.Controllers" }
            );
            // BecomeVolunteer
            routes.MapRoute(
                name: "BecomeVolunteer",
                url: "BecomeVolunteer",
                defaults: new { controller = "BecomeVolunteer", action = "Index", id = UrlParameter.Optional },
                new[] { "Give_Aid.Controllers" }
            );
            // Faq
            routes.MapRoute(
                name: "Faq",
                url: "Faq",
                defaults: new { controller = "Faq", action = "Index", id = UrlParameter.Optional },
                new[] { "Give_Aid.Controllers" }
            );

            // search
            routes.MapRoute(
               name: "Search",
               url: "search",
               defaults: new { controller = "Fund", action = "Search", id = UrlParameter.Optional },
               new[] { "Give_Aid.Controllers" }
           );
            
            // donate
            routes.MapRoute(
               name: "Donate list",
               url: "Donate",
               defaults: new { controller = "Donate", action = "DonateList", id = UrlParameter.Optional },
               new[] { "Give_Aid.Controllers" }
           );

            // customer
            routes.MapRoute(
               name: "Customer login",
               url: "Login",
               defaults: new { controller = "Customer", action = "Login", id = UrlParameter.Optional },
               new[] { "Give_Aid.Controllers" }
           );
            
            routes.MapRoute(
               name: "Customer register",
               url: "Register",
               defaults: new { controller = "Customer", action = "Register", id = UrlParameter.Optional },
               new[] { "Give_Aid.Controllers" }
           );
            
            routes.MapRoute(
               name: "Customer Logout",
               url: "Logout",
               defaults: new { controller = "Customer", action = "Logout", id = UrlParameter.Optional },
               new[] { "Give_Aid.Controllers" }
           );

            routes.MapRoute(
               name: "Customer information",
               url: "Information/-{cusId}",
               defaults: new { controller = "Customer", action = "Information", id = UrlParameter.Optional },
               new[] { "Give_Aid.Controllers" }
           );

            // imageGallery

            routes.MapRoute(
               name: "Image gallery",
               url: "ImagesGallery/{metatitle}-{imgId}",
               defaults: new { controller = "ImagesGallery", action = "ImagesDetail", id = UrlParameter.Optional },
               new[] { "Give_Aid.Controllers" }
           );

            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "Give_Aid.Controllers" }
            );
        }
    }
}
