using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ComicBookLibraryManagerWebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ComicBookArtists",
                url: "ComicBookArtists/{action}/{comicbookid}/{id}",
                defaults: new { controller = "ComicBookArtists", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "ComicBooks", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
