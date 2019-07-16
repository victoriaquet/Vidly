using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            ////rutas creadas por mi:
            //routes.MapRoute(
            //    //nombro la ruta unívocamente
            //     "MoviesByReleaseDate",
            //     //escribo el url que utilizará.. no importa el metodo acá
            //     "movies/released/{year}/{month}",
            //    //relaciono la ruta con un controlador y su método específico
            //     new { controller = "Movies", action = "ByReleaseDate" },
            //    //con expresiones regulares creo restricciones para los parámetros: CONSTRAINTS
            //     new { year = @"2018|2019", month = "\\d{2}" }
            //                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
