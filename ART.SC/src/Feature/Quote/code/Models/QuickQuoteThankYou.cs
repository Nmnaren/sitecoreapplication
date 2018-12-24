using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ART.SC.Foundation.Services.Models;
namespace ART.SC.Feature.Quote.Models
{
    public class QuickQuoteThankYou : QuickQuoteSuccessModel
    {
        public Item Item { get; set; }
    }
}