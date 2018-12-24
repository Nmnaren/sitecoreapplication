using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Globalization;
using Sitecore.Diagnostics;

namespace ART.SC.Foundation.SitecoreExtensions.Infustructure.Events
{
    public class ClearDictionaryCache
    {
        public void ClearCache(object sender, EventArgs args)
        {
            Translate.ResetCache(true);
            Log.Info("Dictionary Cache cleared", this);
        }
    }
}