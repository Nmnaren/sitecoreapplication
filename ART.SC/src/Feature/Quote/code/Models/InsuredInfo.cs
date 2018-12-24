using ART.SC.Feature.Quote.Attributes;
using ART.SC.Foundation.SitecoreExtensions.Extensions;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ART.SC.Feature.Quote.Models
{
    public class InsuredInfo
    {
        public Item Item { get; set; }

        [Required(ErrorMessage = "First Name shouldn't be blank")]
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        [Required(ErrorMessage = "Last Name shouldn't be blank")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date Of Birth shouldn't be blank")]
        [DateGreaterThanCurrent("yyyy-MM-dd", "EARLIER", "Date Of Birth shouldn't be grater than current date")]
        public string DateOfBirth { get; set; }

        [Required(ErrorMessage = "City shouldn't be blank")]
        public string City { get; set; }
        public IEnumerable<string> CityList { get; set; }

        [Required(ErrorMessage = "Address Line1 shouldn't be blank")]
        public string AddressLine1 { get; set; }

        [Required(ErrorMessage = "Address Line2 shouldn't be blank")]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "ZipCode shouldn't be blank")]
        public string ZipCode { get; set; }
    }
}