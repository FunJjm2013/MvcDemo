using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Web.Extension.Filters
{
    public class CurAuthAttribute:AuthorizeAttribute
    {
        public CurAuthAttribute(string role)
        {
            Roles = role;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            string role = httpContext.Request["role"];
            if (!string.IsNullOrWhiteSpace(role))
            {
                return Roles.Contains(role);
            }
            return base.AuthorizeCore(httpContext); 
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("~/Member/User/Login");
        }
    }
}
