using System.Web.Mvc;

namespace MVCDemo.Web.Areas.MVCStudy
{
    public class MVCStudyAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "MVCStudy";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "MVCStudy_default",
                "MVCStudy/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}