using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.BLL;
using MVCDemo.IBLL;
using MVCDemo.Models;
using MVCDemo.Web.Models;

namespace MVCDemo.Web.Areas.Member.Controllers
{
    /// <summary>
    /// 咨询控制器
    /// </summary>
    [Authorize]
    public class ConsultationController : Controller
    {
        private InterfaceCommonModelService commonModelService;
        public ConsultationController()
        {
            commonModelService = new CommonModelService();
        }
        //
        // GET: /Member/Consultation/
        public ActionResult Index(int id)
        {
            return PartialView(commonModelService.Find(id).Consultation);
        }
        /// <summary>
        /// 菜单
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult Menu()
        {
            return PartialView();
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            InterfaceUserService _userService = new UserService();
            var _user = _userService.Find(User.Identity.Name);
            CommonModel _cModel = new CommonModel();
            _cModel.Consultation = new Consultation() { Email=_user.Email,IsPublic=true,Name=_user.DisplayName};
            _user = null;
            _userService = null;
            return View(_cModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CommonModel commonModel)
        {
            if (ModelState.IsValid)
            {
                InterfaceUserService _userService = new UserService();
                var _user = _userService.Find(User.Identity.Name);
                if (commonModel.Article!=null)
                {
                    commonModel.Article = null;
                }
                if (commonModel.Attachment!=null)
                {
                    commonModel.Attachment = null;
                }
                if (commonModel.DefaultPicUrl!=null)
                {
                    commonModel.DefaultPicUrl = null;
                }
                commonModel.Hits = 0;
                commonModel.Inputer = User.Identity.Name;
                commonModel.Model = "Consultation";
                commonModel.ReleaseDate = System.DateTime.Now;
                commonModel.Status = 20;
                commonModel.Consultation.Name = _user.DisplayName;
                _user = null;
                _userService = null;
                commonModel = commonModelService.Add(commonModel);
                if (commonModel.ModelID>0)
                {
                    return View("AddSuccess", commonModel);
                }
            }
            return View(commonModel);
        }
        /// <summary>
        /// 咨询管理
        /// </summary>
        /// <returns></returns>
        public ActionResult ManageList()
        {
            return View();
        }
        
        public JsonResult ManageJsonList(int pageIndex = 1, int pageSize = 20)
        {
            int _total;
            var _list = commonModelService.FindPageList(out _total, pageIndex, pageSize, "Consultation", string.Empty, 0, string.Empty, null, null, 0).ToList().Select(
                cm => new CommonModelViewModel()
                {
                    CategoryID=cm.CategoryID,
                    CategoryName=cm.Category.Name,
                    DefaultPicUrl=cm.DefaultPicUrl,
                    Hits=cm.Hits,
                    Inputer=cm.Inputer,
                    Model=cm.Model,
                    ModelID=cm.ModelID,
                    ReleaseDate=cm.ReleaseDate,
                    Status=cm.Status,
                    Title=cm.Title
                });
            return Json(new { total = _total, rows = _list.ToList() });
        }
        /// <summary>
        /// 我的咨询
        /// </summary>
        /// <returns></returns>
        public ActionResult MyList()
        {
            return View();
        }
        public JsonResult MyJsonList(int pageIndex = 1, int pageSize = 20)
        {
            int _total;
            var _list = commonModelService.FindPageList(out _total, pageIndex, pageSize, "Consultation", string.Empty, 0, User.Identity.Name, null, null, 0).ToList().Select(
                cm => new MVCDemo.Web.Models.CommonModelViewModel()
               {
                    CategoryID = cm.CategoryID,
                    CategoryName = cm.Category.Name,
                    DefaultPicUrl = cm.DefaultPicUrl,
                    Hits = cm.Hits,
                    Inputer = cm.Inputer,
                    Model = cm.Model,
                    ModelID = cm.ModelID,
                    ReleaseDate = cm.ReleaseDate,
                    Status = cm.Status,
                    Title = cm.Title
                });
            return Json(new { total = _total, rows = _list.ToList() });
        }
        /// <summary>
        /// 回复
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public ActionResult Reply(int id)
        {
            return View(commonModelService.Find(id).Consultation);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reply()
        {
            CommonModel _commonModel = null;
            if (RouteData.Values.ContainsKey("id"))
            {
                int _modelId = int.Parse(RouteData.Values["id"].ToString());
                _commonModel = commonModelService.Find(_modelId);
                if (string.IsNullOrEmpty(Request.Form["ReplyContent"]))
                {
                    ModelState.AddModelError("ReplyContent","必须输入回复内容！");
                }
                else
                {
                    _commonModel.Consultation.ReplyContent=Request.Form["ReplyContent"];
                    _commonModel.Consultation.ReplyTime = DateTime.Now;
                    _commonModel.Status = 29;
                    commonModelService.Update(_commonModel);
                }
            }
            return View(_commonModel.Consultation);
        }
    }
}