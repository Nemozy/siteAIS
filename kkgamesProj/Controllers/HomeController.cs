using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kkgamesProj.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "О нас.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Связь с нами.";

            return View();
        }
    }
}