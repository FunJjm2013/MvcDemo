using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.BLL;
using MVCDemo.IBLL;

namespace MVCDemo.Web.Areas.Member.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private InterfaceCategoryService categoryRepository;
        public CategoryController()
        {
            categoryRepository = new CategoryService();
        }
        // GET: Member/Category
        public ActionResult Index()
        {
            return View();
        }
    }
}