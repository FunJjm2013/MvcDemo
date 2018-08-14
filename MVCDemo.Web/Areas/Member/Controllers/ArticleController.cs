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
    public class ArticleController : Controller
    {
        private InterfaceArticleService articleService;
        private InterfaceCommonModelService commomModelService;
        public ArticleController()
        {
            articleService = new ArticleService();
            commomModelService = new CommonModelService();
        }
        // GET: Member/Article
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CommonModel commonModel)
        {
            if (ModelState.IsValid)
            {
                //设置固定值
                commonModel.Hits = 0;
                commonModel.Inputer = User.Identity.Name;
                commonModel.Model = "Article";
                commonModel.ReleaseDate = DateTime.Now;
                commonModel.Status = 99;
                commonModel = commomModelService.Add(commonModel);
                if (commonModel.ModelID > 0)
                {
                    //附件处理
                    InterfaceAttachmentService attachmentService = new AttachmentService();
                    //查询相关附件
                    var attachment = attachmentService.FindList(null, User.Identity.Name, string.Empty).ToList();
                    //遍历附件
                    foreach (var att in attachment)
                    {
                        var filePath = Url.Content(att.FileParth);
                        if ((commonModel.DefaultPicUrl != null && commonModel.DefaultPicUrl.IndexOf(filePath) >= 0) || commonModel.Article.Content.IndexOf(filePath) > 0)
                        {
                            att.ModelID = commonModel.ModelID;
                            attachmentService.Update(att);
                        }
                        //未使用改附件则删除附件和数据库中的记录
                        else
                        {
                            System.IO.File.Delete(Server.MapPath(att.FileParth));
                            attachmentService.Delete(att);
                        }
                    }
                    return View("AddSucess", commonModel);
                }
            }
            return View(commonModel);
        }
        public ActionResult JsonList(string title,string input,Nullable<int> category,Nullable<DateTime> fromDate,Nullable<DateTime> toDate,int pageIndex=1,int pageSize=20)
        {
            if (category==null)
            {
                category = 0;
            }
            int _total;
            var rows = commomModelService.FindPageList(out _total, pageIndex, pageSize, "Article", title, (int)category, input, fromDate, toDate, 0).Select(
                cm => new CommonModelViewModel()
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
            return Json(new { total = _total, rows = rows.ToList() });
            
        }
        /// <summary>
        /// 全部文章
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            return View();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">文章ID</param>
        /// <returns></returns>
        public JsonResult Delete(int id)
        {
            //删除附件
            var _commonModel = commomModelService.Find(id);
            if (_commonModel==null)
            {
                return Json(false);
            }
            //删除附件文件
            foreach (var _attachment in _commonModel.Attachment)
            {
                System.IO.File.Delete(Server.MapPath(_attachment.FileParth));
            }
            if (commomModelService.Delete(_commonModel))
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            return View(commomModelService.Find(id));
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit()
        {
            int _id = int.Parse(ControllerContext.RouteData.GetRequiredString("id"));
            var _commonModel = commomModelService.Find(_id);
            TryUpdateModel(_commonModel, new string[] { "CategoryID", "Title", "DefaultPicUrl" });
            TryUpdateModel(_commonModel.Article, "Article", new string[] { "Author", "Source", "Intro", "Content" });
            if (ModelState.IsValid)
            {
                if (commomModelService.Update(_commonModel))
                {
                    //附件处理
                    InterfaceAttachmentService _attachmentService=new AttachmentService();
                    var _attachments = _attachmentService.FindList(_commonModel.ModelID, User.Identity.Name, string.Empty, true).ToList();
                    foreach (var _att in _attachments)
                    {
                        var _filePath = Url.Content(_att.FileParth);
                        if (_commonModel.DefaultPicUrl!=null&&_commonModel.DefaultPicUrl.IndexOf(_filePath)>=0||_commonModel.Article.Content.IndexOf(_filePath)>0)
                        {
                            _att.ModelID = _commonModel.ModelID;
                            _attachmentService.Update(_att);
                        }
                        else
                        {
                            System.IO.File.Delete(Server.MapPath(_att.FileParth));
                            _attachmentService.Delete(_att);
                        }
                    }
                    return View("EditSucess", _commonModel);
                }
            }
            return View(_commonModel);
        }

        public ActionResult MyList()
        {
            return View();
        }

        public ActionResult MyJsonList(string title,Nullable<DateTime> fromDate,Nullable<DateTime> toDate,int pageIndex=1,int pageSize=20)
        {
            int _total;
            var _rows=commomModelService.FindPageList(out _total,pageIndex,pageSize,"Article",title,0,string.Empty,fromDate,toDate,0).Select(
                cm=>new CommonModelViewModel()
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
            return Json(new { total = _total, rows = _rows.ToList() },JsonRequestBehavior.AllowGet);
        }
        //菜单
        [ChildActionOnly]
        public ActionResult Menu()
        {
            return PartialView();
        }
    }
}