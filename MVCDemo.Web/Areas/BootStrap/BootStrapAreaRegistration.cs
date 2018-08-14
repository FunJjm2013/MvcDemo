using System.Web.Mvc;

namespace MVCDemo.Web.Areas.BootStrap
{
    public class BootStrapAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "BootStrap";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name:"BootStrap_default",
                url: "BootStrap/{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}