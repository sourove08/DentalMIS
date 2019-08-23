using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DENTALMIS.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            //routes.MapRoute(
            //    name:"Script",
            //    url:"Scripts/scerp.constant.js",
            //    defaults: new { controller="Script" , action="Index"},
            //    namespaces: new []{"DENTALMIS.Web.Controllers"}
            //    );
            //routes.MapRoute(
            //   "DrugSection_default",
            //   "DrugSection/{controller}/{action}/{id}",
            //   new { action = "Index", id = UrlParameter.Optional }

            //   );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "DeshBoard", id = UrlParameter.Optional },
                namespaces: new[] { "DENTALMIS.Web.Controllers" }
            );
        }
    }
}
