using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Common;
using System.Drawing;
using MVCDemo.Web.Areas.Member.Models;
using MVCDemo.Models;
using MVCDemo.IBLL;
using MVCDemo.BLL;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;

namespace MVCDemo.Web.Areas.Member.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private InterfaceUserService userService;
        public UserController()
        {
            userService = new UserService();
        }
        #region 属性
        private IAuthenticationManager AuthenticationManager { get { return HttpContext.GetOwinContext().Authentication; } }
        #endregion
        
        // GET: Member/User
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 验证码
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult VerificationCode()
        {
            string verificationCode = Security.CreateVerificationText(6);
            Bitmap img = Security.CreateVerificationImage(verificationCode, 160, 160);
            img.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            TempData["VerificationCode"] = verificationCode.ToUpper();
            return null;
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register(RegisterViewModel register)
        {
            if (TempData["VerificationCode"] == null || TempData["VerificationCode"].ToString() != register.VerificationCode.ToUpper())
            {
                ModelState.AddModelError("VerificationCode", "验证码不正确");
                return View(register);
            }
            if (ModelState.IsValid)
            {
                if (userService.Exist(register.UserName))
                {
                    ModelState.AddModelError("UserName", "用户名已存在");
                }
                else
                {
                    User user = new User()
                    {
                        UserName = register.UserName,
                        DisplayName = register.DisplayName,
                        Password = Security.Sha256(register.Password),
                        Email = register.Email,
                        Status = 0,
                        RegistrationTime = DateTime.Now
                    };
                    user = userService.Add(user);
                    if (user.UserID > 0)
                    {
                        var identity = userService.CreateIndentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                        AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                        AuthenticationManager.SignIn(identity);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "注册失败！");
                    }
                }
            }
            return View(register);
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="returnUrl">返回Url</param>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = userService.Find(loginViewModel.UserName);
                if (user==null)
                {
                    ModelState.AddModelError("UserName", "用户名不存在");
                }
                else if (user.Password == Common.Security.Sha256(loginViewModel.Password))
                {
                    user.LoginTime = System.DateTime.Now;
                    user.LoginIP = Request.UserHostAddress;
                    userService.Update(user);
                    var identity = userService.CreateIndentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = loginViewModel.RememberMe }, identity);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Password", "密码错误");
                }
            }
            return View();
        }
        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return Redirect(Url.Content("~"));
        }
        /// <summary>
        /// 用户导航栏
        /// </summary>
        /// <returns>分部视图</returns>
        public ActionResult Menu()
        {
            return PartialView();
        }
        /// <summary>
        /// 显示资料
        /// </summary>
        /// <returns></returns>
        public ActionResult Details()
        {
            return View(userService.Find(User.Identity.Name));
        }
        /// <summary>
        /// 修改资料
        /// </summary>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Modify()
        {
            var user = userService.Find(User.Identity.Name);
            if (user==null)
            {
                ModelState.AddModelError("", "用户不存在");
            }
            else
            {
                if (TryUpdateModel(user,new string[] { "DisplayName","Email"}))
                {
                    if (ModelState.IsValid)
                    {
                        if (userService.Update(user))
                        {
                            ModelState.AddModelError("","修改成功！");
                        }
                        else
                        {
                            ModelState.AddModelError("", "无需修改的资料");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "更新数据模型失败");
                    }
                }
            }
            return View("Details", user);
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel passwordViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = userService.Find(User.Identity.Name);
                if (user.Password == Common.Security.Sha256(passwordViewModel.ConfirmPassword))
                {
                    user.Password = Common.Security.Sha256(passwordViewModel.Password);
                    if (userService.Update(user))
                    {
                        ModelState.AddModelError("", "修改密码成功");
                    }
                    else
                    {
                        ModelState.AddModelError("", "修改密码失败");
                    }
                }
                else
                {
                    ModelState.AddModelError("","原密码错误");
                }
            }
            return View(passwordViewModel);
        }
    }
}