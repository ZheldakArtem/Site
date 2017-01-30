using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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


    }
}
