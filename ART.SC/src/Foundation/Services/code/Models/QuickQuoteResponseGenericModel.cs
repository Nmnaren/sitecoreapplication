using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
namespace ART.SC.Foundation.Services.Models
{
    public class QuickQuoteResponseGenericModel
    {
        [JsonRequired]
        public bool isSuccess { get; set; }
        [JsonRequired]
        public string responseDate { get; set; }
    }
}