using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Web.Areas.StoredProcedure.Controllers
{
    public class HomeController : Controller
    {
        // GET: StoredProcedure/Home
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