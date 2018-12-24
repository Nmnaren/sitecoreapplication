using Sitecore.Data.Items;
using System;

namespace ART.SC.Foundation.SitecoreExtensions.Repositories
{
    public interface IDictionaryPhraseRepository
    {
        string Get(string key);
    }
}