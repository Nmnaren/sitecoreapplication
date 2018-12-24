using ART.SC.Feature.Quote.App_Start;
using Sitecore.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace ART.SC.Feature.Quote.Infrastructure.Pipelines
{
    public class InitializeRoutes
    {
        public void Process(PipelineArgs args)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}