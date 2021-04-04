using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LaptopShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CheckDuplicateUserName",
                url: "Home/User/CheckDuplicate",
                defaults: new { controller = "User", action = "CheckDuplicateUsername", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "ChecOldPass",
                url: "Home/User/CheckOldPass",
                defaults: new { controller = "User", action = "CheckOldPass", id = UrlParameter.Optional }
            );
        }
    }
}
