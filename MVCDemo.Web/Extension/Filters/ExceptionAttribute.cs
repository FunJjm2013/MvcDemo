using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVCDemo.Web.Extension.Filters
{
    public class ExceptionAttribute:HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                filterContext.Result = new RedirectResult("~/Views/Shared/Error.cshtml");
                filterContext.ExceptionHandled = true;
            }
            base.OnException(filterContext);
        }
    }
}
