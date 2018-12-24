using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ART.SC.Feature.Quote.Models
{
    public class QuickQuote
    {
        public Item Item { get; set; }
        public Policy PolicyDetails { get; set; }
        public VehicleInfo VehicleDetails { get; set; }
        public InsuredInfo InsuredDetails { get; set; }
        public License LicenseDetails { get; set; }
        public bool HasError { get; set; }
        public string GenericErrorMessege { get; set; }
    }
}