using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ART.SC.Foundation.Services.Models
{
    public class QuickQuoteErrorModel : QuickQuoteResponseGenericModel
    {
        public Error Error { get; set; }
    }
    public class ErrorList
    {
        [JsonRequired]
        public string Code { get; set; }
        [JsonRequired]
        public string Description { get; set; }
    }

    public class Error
    {
        public List<ErrorList> ErrorList { get; set; }
    }
}