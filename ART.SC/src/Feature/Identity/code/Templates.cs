using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ART.SC.Feature.Identity
{
    public struct Templates
    {
        public struct Identity
        {
            public static readonly ID ID = new ID("{66675140-EBC4-4384-9FC9-4294FD55C9BF}");

            public struct Fields
            {
                public static readonly ID Logo = new ID("{1B7AC3C8-67FC-4162-9263-A2C92D34B0E9}");
                public static readonly ID Copyright = new ID("{BFA47C4B-76CF-4717-A6C4-7A98EF762CDD}");

            }
        }
    }
}