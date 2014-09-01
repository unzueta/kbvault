﻿using System.Web;
using System.Web.Optimization;

namespace KBVault.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/public/js").Include(
            "~/Assets/js/bootstrap.js",
            "~/Assets/js/jquery.cookie.js",
            "~/Assets/js/frontend.js",
            "~/Assets/js/smartmenus/jquery.smartmenus.keyboard.js",
            "~/Assets/js/smartmenus/jquery.smartmenus.bootstrap.js",
            "~/Assets/js/smartmenus/jquery.smartmenus.js"
                ));

            bundles.Add( new StyleBundle("~/public/css").Include(
                "~/Assets/css/bootstrap.css",
                "~/Assets/css/font-awesome.css",
                "~/Assets/css/ionicons.css",
                "~/Assets/css/site.css",
                "~/Assets/css/jquery.smartmenus.bootstrap.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Assets/js/bootstrap.js",
                "~/Assets/js/AdminLTE/app.js",
                "~/Assets/ckeditor/ckeditor.js",
                "~/Assets/js/tag-it.js",
                "~/Assets/js/jquery.uploadfile.js",
                "~/Assets/js/kbvault.js"
                ));

            bundles.Add(new StyleBundle("~/admin/css").Include(
                "~/Assets/css/bootstrap.css",
                "~/Assets/css/font-awesome.css",
                "~/Assets/css/AdminLTE.css",
                "~/Assets/css/ionicons.css",
                "~/Assets/css/jquery.tagit.css",
                "~/Assets/css/tagit.ui-zendesk.css",
                "~/Assets/css/uploadfile.css"
                ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            /*
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            */
            //bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            
        }
    }
}