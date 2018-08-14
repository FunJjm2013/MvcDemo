using System.Web.Mvc;

namespace MVCDemo.Web.Areas.DataStructures
{
    public class DataStructuresAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "DataStructures";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "DataStructures_default",
                "DataStructures/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}