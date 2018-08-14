using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Web.Areas.HTML5CSS3.Controllers
{
    public class HomeController : Controller
    {
        // GET: HTML5CSS3/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Grammer()
        {
            return View();
        }
    }
}