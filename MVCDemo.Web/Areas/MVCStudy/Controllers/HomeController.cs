using MVCDemo.Web.Extension.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Web.Areas.MVCStudy.Controllers
{
    public class HomeController : Controller
    {
        // GET: MVCStudy/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Welcome()
        {
            //throw new ApplicationException();
            return View();
        }
        public ActionResult Grammer()
        {
            return View();
        }
    }
}