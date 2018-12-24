using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ART.SC.Foundation.Services.ApiClient;
using ART.SC.Foundation.DependencyInjection;
using Sitecore.Configuration;
using ART.SC.Foundation.Services.Models;
using Sitecore.Diagnostics;

namespace ART.SC.Foundation.Services.Service
{
    [Service]
    public class MotorVehicleDetailsService
    {
        private string ApiBaseUrl => Settings.GetSetting("MasterDataApi.ApiBaseUrl");
        
        public MotorVehicleDetails GetCarDetailsBasedOnSelection(string selection)
        {
            Assert.IsNotNullOrEmpty(selection, "Car type is missing");

            ApiClient.ApiClient client = new ApiClient.ApiClient(new Uri(ApiBaseUrl));
            string relativePath = $"{ApiType.vehicles.ToString()}/{selection}";
            var requestUri = client.CreateRequestUri(relativePath);
            var response = client.getAsync<MotorVehicleDetails>(requestUri);
            if(response != null && !string.IsNullOrWhiteSpace(response.Name))
            {
                return response;
            }
            return null;
        }
    }
}