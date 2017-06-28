using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoFua.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        [Authorize]
        public ActionResult Dashboard()
        {
            ViewBag.Message = "Your dashboard page.";

            return View();
        }



        public ActionResult News()
        {
            ViewBag.Message = "Your application News page.";

            return View();
        }

        public ActionResult Touch()
        {
            ViewBag.Message = "Your application News page.";

            return View();
        }

        public ActionResult Market()
        {
            ViewBag.Message = "Your application News page.";

            return View();
        }

         public ActionResult Team()
        {
            ViewBag.Message = "Your application Team page.";

            return View();
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}