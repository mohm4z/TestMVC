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
            bundles.Add(new ScriptBundle("~/Scripts/jquery").Include(
                "~/App_Themes/Template/assets/global/plugins/jquery-{version}.js",
                //"~/App_Themes/Template/assets/global/plugins/jquery.min",
                "~/App_Themes/Template/assets/global/plugins/bootstrap/js/bootstrap.min",
                "~/App_Themes/Template/assets/global/plugins/js.cookie.min",
                "~/App_Themes/Template/assets/global/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min",
                "~/App_Themes/Template/assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min",
                "~/App_Themes/Template/assets/global/plugins/jquery.blockui.min",
                "~/App_Themes/Template/assets/global/plugins/uniform/jquery.uniform.min",
                "~/App_Themes/Template/assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min",
                "~/App_Themes/Template/assets/global/scripts/app.min",
                "~/App_Themes/Template/assets/layouts/layout/scripts/layout.min",
                "~/App_Themes/Template/assets/layouts/layout/scripts/demo.min",
                "~/App_Themes/Template/assets/layouts/global/scripts/quick-sidebar.min"
            ));

            bundles.Add(new StyleBundle("~/Style/css").Include(
                "~/App_Themes/Template/assets/global/plugins/font-awesome/css/font-awesome.min",
                "~/App_Themes/Template/assets/global/plugins/simple-line-icons/simple-line-icons.min",
                "~/App_Themes/Template/assets/global/plugins/bootstrap/css/bootstrap-rtl.min",
                "~/App_Themes/Template/assets/global/plugins/uniform/css/uniform.default.min",
                "~/App_Themes/Template/assets/global/plugins/bootstrap-switch/css/bootstrap-switch-rtl.min",
                "~/App_Themes/Template/assets/global/css/components-rtl.min",
                "~/App_Themes/Template/assets/global/css/plugins-rtl.min",
                "~/App_Themes/Template/assets/layouts/layout/css/layout-rtl.min",
                "~/App_Themes/Template/assets/layouts/layout/css/themes/darkblue-rtl.min",
                "~/App_Themes/Template/assets/layouts/layout/css/custom-rtl.min"
                //<link href="/App_Themes/MainTheme/css/animate",
                //<link href="/App_Themes/MainTheme/css/MainCss",

                ));
        }
    }
}