using ART.SC.Feature.Quote.Attributes;
using ART.SC.Foundation.SitecoreExtensions.Extensions;
using ART.SC.Foundation.SitecoreExtensions.Repositories;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ART.SC.Feature.Quote.Models
{
    public class Policy
    {
        public Item Item { get; set; }

        [Required(ErrorMessage = "Policy Effective date shouldn't be blank")]
        [DateGreaterThanCurrent("yyyy-MM-dd", "GREATER", "Policy Effective date should be grater than current date")]
        public string PolicyEffectiveDate { get; set; }

        [Required(ErrorMessage = "Policy Expiry date shouldn't be blank")]
        public string PolicyExpiryDate { get; set; }

        [Required(ErrorMessage = "Policy Coverage amount shouldn't be blank")]
        public long CoverageAmount { get; set; }
    }
}