using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Web.Areas.Member.Controllers
{
    /// <summary>
    /// 会员主页控制器
    /// <remarks>
    /// 创建：2015-05-04
    /// </remarks>
    /// </summary>
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Member/Home
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult Menu()
        {
            return PartialView();
        }
    }
}