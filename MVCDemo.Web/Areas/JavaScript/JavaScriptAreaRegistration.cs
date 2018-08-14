using System.Web.Mvc;

namespace MVCDemo.Web.Areas.JavaScript
{
    public class JavaScriptAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "JavaScript";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "JavaScript_default",
                "JavaScript/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}