using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MVC_ERP_Systems
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {



            bundles.Add(new StyleBundle("~/Style/css").Include(
                "~/App_Themes/Template/assets/global/plugins/mapplic/css/font-awesome.css",
                "~/App_Themes/Template/assets/global/plugins/simple-line-icons/simple-line-icons.min.css",
                "~/App_Themes/Template/assets/global/plugins/bootstrap/css/bootstrap-rtl.min.css",
                "~/App_Themes/Template/assets/global/plugins/uniform/css/uniform.default.min.css",
                "~/App_Themes/Template/assets/global/plugins/bootstrap-switch/css/bootstrap-switch-rtl.min.css",
                "~/App_Themes/Template/assets/global/css/components-rtl.min.css",
                "~/App_Themes/Template/assets/global/css/plugins-rtl.min.css",
                "~/App_Themes/Template/assets/layouts/layout/css/layout-rtl.min.css",
                "~/App_Themes/Template/assets/layouts/layout/css/themes/darkblue-rtl.min.css",
                "~/App_Themes/Template/assets/layouts/layout/css/custom-rtl.min.css",
                "~/App_Themes/Theme/css/MainCss.css",
                //"~/App_Themes/Theme/css/animate.css",

                //"~/Content/ui-bootstrap-csp.css"

                "~/App_Themes/Theme/Plugins/Select2/select2.min.css"
                ));


            bundles.Add(new ScriptBundle("~/Scripts/js").Include(
                "~/App_Themes/Template/assets/global/plugins/jquery.min.js",
                "~/App_Themes/Template/assets/global/plugins/bootstrap/js/bootstrap.min.js",
                "~/App_Themes/Template/assets/global/plugins/js.cookie.min.js",
                "~/App_Themes/Template/assets/global/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js",
                "~/App_Themes/Template/assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js",
                "~/App_Themes/Template/assets/global/plugins/jquery.blockui.min.js",
                "~/App_Themes/Template/assets/global/plugins/uniform/jquery.uniform.min.js",
                "~/App_Themes/Template/assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js",
                "~/App_Themes/Template/assets/global/scripts/app.min.js",
                "~/App_Themes/Template/assets/layouts/layout/scripts/layout.min.js",
                "~/App_Themes/Template/assets/layouts/layout/scripts/demo.min.js",
                "~/App_Themes/Template/assets/layouts/global/scripts/quick-sidebar.min.js",

                "~/Scripts/angular.min.js",
                //"~/Resource/ui-bootstrap-tpls-0.13.4.min.js"
                "~/Scripts/angular-ui/ui-bootstrap-tpls.min.js",
                //"~/Scripts/AngApp.js"
            
                "~/App_Themes/Theme/Plugins/Select2/select2.full.min.js",
                "~/App_Themes/Theme/Plugins/Select2/select2.min.js"
           ));
        }
    }
}