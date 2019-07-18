using System.Web;
using System.Web.Mvc;
using WebSocialWeb.Filters;

namespace WebSocialWeb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CustomExceptionHandler());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
