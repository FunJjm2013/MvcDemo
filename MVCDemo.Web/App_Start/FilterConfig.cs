using MVCDemo.Web.Extension.Filters;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new CurActionAttribute());
        }
    }
}
