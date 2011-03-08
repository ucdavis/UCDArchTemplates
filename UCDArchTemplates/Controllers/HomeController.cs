using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UCDArchTemplates.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            var type = typeof (CustomerViewModel);

            var vm = type.Name.Substring(0, "ViewModel".Length - 1);
            
            var c = type.GetProperty("Customer");


            return View();
        }
    }
}
