﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DoAnQLNS
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "MyDefault1",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "ChucVu", action = "Details", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "MyDefault2",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "NhanVien", action = "DSNV", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
            
        }
    }
}
