using System.Web.Routing;

namespace WebFormsFull
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(
                "",
                "Default",
                "~/Default.aspx"
                );
            routes.MapPageRoute(
                "OtherPage",
                "OtherPage",
                "~/OtherPage.aspx"
                );
        }
    }
}
