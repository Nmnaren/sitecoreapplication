using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ART.SC.Foundation.Services.Models
{
    public class QuickQuoteResponseModel
    {
        public QuickQuoteErrorModel ErrorModel { get; set; }
        public QuickQuoteSuccessModel SuccessModel { get; set; }
    }
}