using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ART.SC.Foundation.DependencyInjection;
using Sitecore.Configuration;
using ART.SC.Foundation.Services.Models;
using Sitecore.Diagnostics;

namespace ART.SC.Foundation.Services.Service
{
    [Service]
    public class MasterDataService
    {
        private string ApiBaseUrl => Settings.GetSetting("MasterDataApi.ApiBaseUrl");

        public MasterDetails GetMasterDetailsForVehicles()
        {
            ApiClient.ApiClient client = new ApiClient.ApiClient(new Uri(ApiBaseUrl));
            var requestUri = client.CreateRequestUri(ApiClient.ApiType.vehicles.ToString());
            var response = client.getAsync<MasterDetails>(requestUri);
            if (response != null && response.masterData != null)
            {
                return response;
            }
            return null;
        }
    }
}