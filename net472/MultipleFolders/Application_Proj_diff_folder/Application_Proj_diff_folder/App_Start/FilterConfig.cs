using System.Web;
using System.Web.Mvc;

namespace Application_Proj_diff_folder
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
