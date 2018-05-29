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
                "~/App_Themes/Template/assets/global/plugins/jquery-{version}.js"
            ));

            //bundles.Add(new StyleBundle("~/Style/css").Include(
            //     "~/Scripts/Lib/jquery/jquery-{version}.js"
            //    ));
        }
    }
}