﻿using System.Web;
using System.Web.Optimization;

namespace WebSite
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery/jquery-{version}.js",
                        "~/Scripts/scroll.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery/jquery.unobtrusive*",
                        "~/Scripts/jquery/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/angular/angular.js",
                 "~/Scripts/underscore/underscore-min.js",
                 "~/Scripts/angular/services/underscoreService.js",
                "~/Scripts/angular/controllers/driveController.js",
                "~/Scripts/angular/services/systemService.js",
                 "~/Scripts/config.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/admin").Include(
              "~/Scripts/angular/angular.js",
              "~/Scripts/underscore/underscore-min.js",
              "~/Scripts/angular/services/underscoreService.js",
              "~/Scripts/angular/controllers/adminController.js",
              "~/Scripts/angular/services/adminService.js",
              "~/Scripts/config.js"));

            bundles.Add(new ScriptBundle("~/bundles/tests").Include("~/Scripts/jasmine/jasmine.js",
                "~/Scripts/jasmine/jasmine-html.js",
                "~/Scripts/jasmine/jasmine-bootstrap.js",
                "~/Scripts/angular/angular.js",
                "~/Scripts/angular/angular-mocks.js",
                "~/Scripts/angular/controllers/driveController.js",
                "~/Scripts/angular/services/systemService.js",
                "~/Scripts/config.js",
                "~/Scripts/app-spec.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css", "~/Content/web-site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}