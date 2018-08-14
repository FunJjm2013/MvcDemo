using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Web.Areas.DataStructures.Controllers
{
    public class HomeController : Controller
    {
        // GET: DataStructures/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}