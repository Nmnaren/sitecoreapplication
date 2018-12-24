using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ART.SC.Feature.Quote.App_Start
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute("quote-getmotorvehcledetails", "api/feature/quote/getmotorvehcledetails", new { controller = "Quote", action = "GetMotorVehcleDetails", id = UrlParameter.Optional });
        }
    }
}