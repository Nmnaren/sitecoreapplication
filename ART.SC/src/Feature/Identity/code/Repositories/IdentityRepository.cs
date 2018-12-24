using Sitecore;
using Sitecore.Data.Items;
using ART.SC.Foundation.SitecoreExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ART.SC.Feature.Identity.Repositories
{
    public class IdentityRepository
    {
        public static Item Get([NotNull] Item contextItem)
        {
            if (contextItem == null)
                throw new ArgumentNullException(nameof(contextItem));

            return contextItem.GetAncestorOrSelfOfTemplate(Templates.Identity.ID) ?? Context.Site.GetContextItem(Templates.Identity.ID);
        }
    }
}