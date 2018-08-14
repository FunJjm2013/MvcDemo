using System.Web.Mvc;

namespace MVCDemo.Web.Areas.HTML5CSS3
{
    public class HTML5CSS3AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "HTML5CSS3";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "HTML5CSS3_default",
                "HTML5CSS3/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}