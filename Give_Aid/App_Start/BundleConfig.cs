using System.Web;
using System.Web.Optimization;

namespace Give_Aid
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.unobtrusive-ajax.js", "~/Scripts/jquery.unobtrusive-ajax.min.js", "~/Scripts/jquery.validate*", "~/Scripts/jquery.validate.unobtrusive.js", "~/Scripts/jquery.validate.unobtrusive.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/bundles/core").Include(
                    "~/Content/assets/library/animate/animate.min.css",
                    "~/Content/assets/library/bootstrap/css/bootstrap.min.css",
                    "~/Content/assets/library/bootstrap/css/bootstrap-dropdownhover.min.css",
                    //"~/Content/assets/library/icofont/icofont.min.css",
                    //"~/Content/assets/library/owlcarousel/css/owl.carousel.min.css",
                    //"~/Content/assets/library/select2/css/select2.min.css",
                    //"~/Content/assets/library/magnific-popup/magnific-popup.css",
                    "~/Content/jquery-ui.css",
                    "~/Content/assets/css/style.css",
                    "~/Content/assets/css/home-main.css"
                    ));
            BundleTable.EnableOptimizations = true;
        }
    }
}
