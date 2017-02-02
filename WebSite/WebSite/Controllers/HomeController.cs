using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebSite.Filters;

namespace WebSite.Controllers
{
    [InitializeSimpleMembership]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Test Message";
            return View();
        }

        public ActionResult AdminIndex()
        {
            return View();
        }

        [Authorize(Roles="admin, moderator")]
        public ActionResult TestsIndex()
        {
            return View();
        }
    }
}
