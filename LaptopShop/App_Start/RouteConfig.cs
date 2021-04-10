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

            //Quản lý User
            routes.MapRoute(
                name: "UserManager",
                url: "{controller}/UserManager",
                defaults: new { controller = "User", action = "UserManager", id = UrlParameter.Optional }
            );

            //Update User
            routes.MapRoute(
                name: "UpdateUser",
                url: "{controller}/User/Update/{id}",
                defaults: new { controller = "User", action = "UserManager", id = UrlParameter.Optional }
            );
        }
    }
}
