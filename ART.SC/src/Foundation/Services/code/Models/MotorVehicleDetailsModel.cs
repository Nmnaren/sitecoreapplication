using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ART.SC.Foundation.Services.Models
{
    public class MotorVehicleDetails
    {
        public string Name { get; set; }
        public List<string> Models { get; set; }
        public List<string> Color { get; set; }
        public List<string> Transmission { get; set; }
        public List<string> Class { get; set; }
    }
}