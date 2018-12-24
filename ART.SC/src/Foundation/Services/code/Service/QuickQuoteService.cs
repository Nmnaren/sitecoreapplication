using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ART.SC.Foundation.DependencyInjection;
using Sitecore.Configuration;
using ART.SC.Foundation.Services.Models;
using Sitecore.Diagnostics;
using Newtonsoft.Json;

namespace ART.SC.Foundation.Services.Service
{
    [Service]
    public class QuickQuoteService
    {
        private string ApiBaseUrl => Settings.GetSetting("QuickQuoteApi.ApiBaseUrl");

        public QuickQuoteResponseModel SaveQuickQuoteDetails(QuickQuoteModel quickQuoteData)
        {
            QuickQuoteResponseModel responseModel = new QuickQuoteResponseModel();
            if (quickQuoteData != null)
            {
                try
                {
                    string response = string.Empty;
                    ApiClient.ApiClient client = new ApiClient.ApiClient(new Uri(ApiBaseUrl));
                    var requestUri = client.CreateRequestUri(ApiClient.ApiType.quickQuote.ToString());
                    //requestUri = new Uri("http://localhost:65335/api/QuickQuote/QuickQuotePost");
                    response = client.quickQuotePostAsync(requestUri, quickQuoteData);
                    if (!string.IsNullOrWhiteSpace(response) && response.IndexOf("isSuccess") > 0)
                    {
                        var genericResponse = JsonConvert.DeserializeObject<QuickQuoteResponseGenericModel>(response);
                        if (genericResponse.isSuccess)
                        {
                            responseModel.SuccessModel = JsonConvert.DeserializeObject<QuickQuoteSuccessModel>(response);
                        }
                        else
                        {
                            responseModel.ErrorModel = JsonConvert.DeserializeObject<QuickQuoteErrorModel>(response);
                        }
                    }
                }
                catch (JsonException je)
                {
                    Log.Error("Json exception occured while deserializing the quick quote response", je, typeof(QuickQuoteService));
                }
                catch (Exception ex)
                {
                    Log.Error("Error Happened during SaveQuickQuoteDetails function call ", ex, typeof(QuickQuoteService));
                }

            }
            return responseModel;
        }
    }
}