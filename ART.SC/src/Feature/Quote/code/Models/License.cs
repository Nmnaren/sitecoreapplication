using ART.SC.Feature.Quote.Attributes;
using ART.SC.Foundation.SitecoreExtensions.Extensions;
using Sitecore.Data.Items;
using System.ComponentModel.DataAnnotations;

namespace ART.SC.Feature.Quote.Models
{
    public class License
    {
        public Item Item { get; set; }

        [Required(ErrorMessage = "License number shouldn't be blank")]
        public string LicenseNumber { get; set; }

        [Required(ErrorMessage = "Place of issue shouldn't be blank")]
        public string PlaceOfIssue { get; set; }

        [Required(ErrorMessage = "License EffectiveDate shouldn't be blank")]
        [DateGreaterThanCurrent("yyyy-MM-dd", "EARLIER", "License Effective date shouldn't be greater than current date")]
        public string EffectiveDate { get; set; }

        [Required(ErrorMessage = "License ExpiryDate shouldn't be blank")]
        [DateGreaterThanCurrent("yyyy-MM-dd", "GREATER", "Policy Expiry date should be grater than current date")]
        [DateGreaterThan("EffectiveDate", "yyyy-MM-dd", "License Expiry date should be greater than Effective date")]
        public string ExpiryDate { get; set; }
    }
}