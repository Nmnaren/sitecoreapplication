using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
namespace ART.SC.Foundation.Services.Models
{
    public class QuickQuoteModel
    {
        [JsonProperty("insuredDetails")]
        public InsuredDetails InsuredDetails { get; set; }
        [JsonProperty("policyDetails")]
        public PolicyDetails PolicyDetails { get; set; }
        [JsonProperty("licenseDetails")]
        public LicenseDetails LicenseDetails { get; set; }
        [JsonProperty("vehicleDetails")]
        public VehicleDetails VehicleDetails { get; set; }
    }
    public class Address
    {
        public List<string> lines { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipCode { get; set; }
    }

    public class InsuredDetails
    {
        public string firstName { get; set; }
        public string secondName { get; set; }
        public string lastName { get; set; }
        public Address address { get; set; }
    }

    public class PolicyDetails
    {
        public long coverageAmount { get; set; }
        public string effectiveDate { get; set; }
        public string expiryDate { get; set; }
    }

    public class LicenseDetails
    {
        public string number { get; set; }
        public string effectiveDate { get; set; }
        public string expiryDate { get; set; }
        public string placeOfIssue { get; set; }
    }

    public class VehicleDetails
    {
        public string make { get; set; }
        public string model { get; set; }
        public string year { get; set; }
        public string color { get; set; }
        public string registration { get; set; }
        public string type { get; set; }
        public string transmission { get; set; }
        public double odometer { get; set; }
        public string usage { get; set; }
        public int distCoveredDaily { get; set; }
    }
}