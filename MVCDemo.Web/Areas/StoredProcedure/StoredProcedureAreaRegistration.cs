using System.Web.Mvc;

namespace MVCDemo.Web.Areas.StoredProcedure
{
    public class StoredProcedureAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "StoredProcedure";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "StoredProcedure_default",
                "StoredProcedure/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}