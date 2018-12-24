using ART.SC.Foundation.DependencyInjection;
using ART.SC.Foundation.SitecoreExtensions.Repositories;
using Sitecore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ART.SC.Foundation.SitecoreExtensions.Extensions
{
    [Service(typeof(IDictionaryPhraseRepository))]
    public class DictionaryExtension: IDictionaryPhraseRepository
    {
        public static IDictionaryPhraseRepository Current => new DictionaryExtension();
        public string Get([NotNull] string key)
        {
           
                if (key == null)
                {
                    throw new ArgumentNullException(nameof(key));
                }
                return Sitecore.Globalization.Translate.Text(key);

        
        }

    }

}