using System.Web.Mvc;

namespace MVCDemo.Web.Areas.JQuery
{
    public class JQueryAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "JQuery";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "JQuery_default",
                "JQuery/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}