using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
namespace ART.SC.Foundation.Services.Models
{
    public class QuickQuoteSuccessModel : QuickQuoteResponseGenericModel
    {
        [JsonRequired]
        public Result Result { get; set; }

    }

    public class Result
    {
        [JsonRequired]
        public string ReferenceNo { get; set; }
        [JsonRequired]
        public string QuoteStatus { get; set; }

        public QuoteDetails QuoteDetails { get; set; }
    }

    public class QuoteDetails
    {
        public double PremiumAmount { get; set; }
        public string TotalCoverage { get; set; }
    }
}