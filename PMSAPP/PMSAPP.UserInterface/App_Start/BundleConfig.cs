using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace PMSAPP.UserInterface
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            ScriptBundle jqueryBundle =
                new ScriptBundle("~/bundles/jquery");
            jqueryBundle.Include("" +
                "~/Scripts/jquery-{version}.min.js",
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/jquery.validate.unobtrusive.min.js"
                );

            ScriptBundle bootstrapScriptBundle =
                new ScriptBundle("~/bundles/bootstrap");
            bootstrapScriptBundle.Include("~/Scripts/bootstarp.min.js");

            StyleBundle bootstrapStyleBundle = new StyleBundle("~/bundles/css");
            bootstrapStyleBundle.Include("~/Content/Site.css");
            bootstrapStyleBundle.Include("~/Content/bootstrap.min.css");

            bundles.Add(jqueryBundle);
            bundles.Add(bootstrapStyleBundle);
            bundles.Add(bootstrapScriptBundle);

            BundleTable.EnableOptimizations = true;
        }
    }
}