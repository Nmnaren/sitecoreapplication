using ART.SC.Foundation.SitecoreExtensions.Extensions;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ART.SC.Feature.Quote.Models
{
    public class VehicleInfo
    {
        public Item Item { get; set; }

        [Required(ErrorMessage = "Vehicle Make shouldn't be blank")]
        public string VehicleMake { get; set; }

        public IEnumerable<string> VehicleMakeList { get; set; }

        [Required(ErrorMessage = "Vehicle Model shouldn't be blank")]
        public string VehicleModel { get; set; }
        public List<string> VehicleModelList { get; set; }

        [Required(ErrorMessage = "Year Of Manufacture shouldn't be blank")]
        public string YearOfManufacture { get; set; }

        [Required(ErrorMessage = "Vehicle Color shouldn't be blank")]
        public string Color { get; set; }

        public List<string> ColorList { get; set; }

        [Required(ErrorMessage = "Vehicle Usage shouldn't be blank")]
        public string VehicleUsage { get; set; }
        public IEnumerable<string> VehicleUsageList { get; set; }

        [Required(ErrorMessage = "ODO Meter Reading shouldn't be blank")]
        public string ODOMeterReading { get; set; }

        [Required(ErrorMessage = "Registration Number shouldn't be blank")]
        public string RegistrationNumber { get; set; }

        [Required(ErrorMessage = "Vehicle Type shouldn't be blank")]
        public string VehicleType { get; set; }
        public List<string> VehicleTypeList { get; set; }

        [Required(ErrorMessage = "Transmission Type shouldn't be blank")]
        public string TransmissionType { get; set; }
        public List<string> TransmissionTypeList { get; set; }
    }
}