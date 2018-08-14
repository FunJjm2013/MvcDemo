using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.BLL;
using MVCDemo.IBLL;
using MVCDemo.Models;
using MVCDemo.Models.Config;
using MVCDemo.Web.Areas.Member.Models;

namespace MVCDemo.Web.Areas.Member.Controllers
{
    /// <summary>
    /// 附件控制器
    /// <remarks>
    /// 创建：2015.04.08
    /// </remarks>
    /// </summary>
    [Authorize]
    public class AttachmentController : Controller
    {
        private InterfaceAttachmentService attachmentService;
        public AttachmentController()
        {
            attachmentService = new AttachmentService();
        }
        // GET: Member/Attachment
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 添加附件
        /// </summary>
        /// <returns>视图页面</returns>
        public ActionResult Add()
        {
            return View();
        }
        /// <summary>
        /// 上传附件
        /// </summary>
        /// <returns></returns>
        public ActionResult Upload()
        {
            var uploadConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~").GetSection("UploadConfig") as UploadConfig;
            //文件最大限制
            int maxSize = uploadConfig.MaxSize;
            //保存路径
            string savePath;
            //文件路径
            string fileParth = "~/" + uploadConfig.Path + "/";
            //文件名
            string fileName;
            //扩展名
            string fileExt;
            //文件类型
            string dirName;
            //允许上传的类型
            Hashtable extTable = new Hashtable();
            extTable.Add("image", uploadConfig.ImageExt);
            extTable.Add("flash", uploadConfig.FileExt);
            extTable.Add("media", uploadConfig.MediaExt);
            extTable.Add("file", uploadConfig.FileExt);
            //上传文件
            HttpPostedFileBase postFile = Request.Files["imgFile"];
            if (postFile==null)
            {
                return Json(new { error = '1', message = "请选择文件" });
            }
            fileName = postFile.FileName;
            fileExt = Path.GetExtension(fileName).ToLower();
            dirName = Request.QueryString["dir"];
            if (string.IsNullOrEmpty(dirName))
            {
                dirName = "image";
            }
            if (!extTable.ContainsKey(dirName))
            {
                return Json(new { error=1,message="目录类型不存在"});
            }
            //文件大小
            if (postFile.InputStream==null||postFile.InputStream.Length>maxSize)
            {
                return Json(new { error = 1, message = "文件大小超过限制" });
            }
            //检查扩展名
            if (string.IsNullOrEmpty(fileExt)||Array.IndexOf(((string)extTable[dirName]).Split(','),fileExt.Substring(1).ToLower())==-1)
            {
                return Json(new { error = 1, message = "不允许上传此类型的文件。\n只允许" + ((String)extTable[dirName]) + "格式。" });
            }
            fileParth += dirName + "/" + DateTime.Now.ToString("yyyy-MM") + "/";
            savePath = Server.MapPath(fileParth);
            //检查上传目录
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }
            string newFileName = DateTime.Now.ToString("yyyyMMdd_hhmmss") + fileExt;
            savePath += newFileName;
            fileParth += newFileName;
            //保存文件
            postFile.SaveAs(savePath);
            attachmentService.Add(new Attachment() {Extension=fileExt.Substring(1), FileParth=fileParth,Owner=User.Identity.Name,UploadDate=DateTime.Now,Type=dirName});
            return Json(new { error = 0, url = Url.Content(fileParth) });
        }
        /// <summary>
        /// 附件管理列表
        /// </summary>
        /// <param name="id">公共模型ID</param>
        /// <param name="dir">目录（类型）</param>
        /// <returns></returns>
        public ActionResult FileManagerJson(int? id,string dir)
        {
            AttachmentManagerViewModel attachmentViewModel;
            IQueryable<Attachment> attachments;
            //Id为null,表示是公共模型ID为null，此时查询数据库中没有跟模型对应起来的附件列表（以上传，但上传的文章。。。还未保存）
            if (id==null)
            {
                attachments = attachmentService.FindList(null, User.Identity.Name, dir);
            }
            //Id不为null，返回指定模型Id和id为null（新上传的附件列表）
            else
            {
                attachments = attachmentService.FindList((int)id, User.Identity.Name, dir, true);
            }
            var attachmentList = new List<AttachmentManagerViewModel>(attachments.Count());
            foreach (var attachment in attachments)
            {
                attachmentViewModel = new AttachmentManagerViewModel() { datetime = attachment.UploadDate.ToString("yyyy-MM-dd HH:mm:ss"), filetype = attachment.Extension, has_file = false, is_dir = false, is_photo = attachment.Type.ToLower() == "image" ? true : false,filename=Url.Content(attachment.FileParth) };
                FileInfo fileInfo = new FileInfo(Server.MapPath(attachment.FileParth));
                attachmentViewModel.filesize = (int)fileInfo.Length;
                attachmentList.Add(attachmentViewModel);
            }
            return Json(new { moveup_dir_path = "", current_dir_path = "", current_url = "", total_count = attachmentList.Count, file_list = attachmentList }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 创建缩略图
        /// </summary>
        /// <param name="originalPicture">原图地址</param>
        /// <returns>缩略图地址，生成失败饭回null</returns>
        public ActionResult CreateThumbnail(string originalPicture)
        {
            //原图为缩略图直接返回其地址
            if (originalPicture.IndexOf("_s")>0)
            {
                return Json(originalPicture);
            }
            //略缩图地址
            string thumbnail = originalPicture.Insert(originalPicture.LastIndexOf('.'),"_s");
            //创建缩略图
            if (Common.Picture.CreateThumbnail(Server.MapPath(originalPicture),Server.MapPath(thumbnail),160,120))
            {
                //记录保存在数据库中
                attachmentService.Add(new Attachment() { Extension = thumbnail.Substring(thumbnail.LastIndexOf('.') + 1), FileParth = "~" + thumbnail, Owner = User.Identity.Name, Type = "image", UploadDate = DateTime.Now });
                return Json(thumbnail);
            }
            return Json(null);
        }
    }
}