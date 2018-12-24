using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ART.SC.Foundation.Services.Models
{
    public class MasterData
    {
        public Motor motor { get; set; }
        public List<string> cities { get; set; }
    }

    public class Motor
    {
        public Vehicle vehicle { get; set; }
    }

    public class Vehicle
    {
        public List<string> Make { get; set; }
        public List<string> Usage { get; set; }
    }
}