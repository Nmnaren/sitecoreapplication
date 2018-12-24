using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http.Headers;
using System.Net;
using Sitecore.Diagnostics;

namespace ART.SC.Foundation.Services.ApiClient
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        private Uri BaseEndPoint { get; set; }
        public ApiClient(Uri baseEndpoint)
        {
            if (baseEndpoint == null)
            {
                return;
            }
            BaseEndPoint = baseEndpoint;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            _httpClient = new HttpClient();
        }

        public T getAsync<T>(Uri requestUri)
        {
            var response = _httpClient.GetAsync(requestUri).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                if (data != null)
                {
                    return JsonConvert.DeserializeObject<T>(data);
                }
            }
            return default(T);
        }
        public T1 postAsync<T1, T2>(Uri requestUrl, T2 content)
        {
            addHeaders();
            var response =  _httpClient.PostAsync(requestUrl.ToString(), createHttpContent<T2>(content)).Result;
            if (response.IsSuccessStatusCode)
            {
                var data =  response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T1>(data);
            }
            return default(T1);
        }

        public string quickQuotePostAsync<T>(Uri requestUrl, T content)
        {
            //addHeaders();
            var httpContent = createHttpContent<T>(content);
            var response = _httpClient.PostAsync(requestUrl, httpContent).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                Log.Info($"Quick quote request erro. Status code {response.StatusCode}", typeof(ApiClient));
                return response.Content.ReadAsStringAsync().Result;
            }
        }
        private HttpContent createHttpContent<T>(T content)
        {
            var json = JsonConvert.SerializeObject(content, MicrosoftDateFormatSettings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
        public Uri CreateRequestUri(string relativePath, string queryString = "")
        {
            var endPoint = new Uri(BaseEndPoint, relativePath);
            var uriBuilder = new UriBuilder(endPoint);
            uriBuilder.Query = queryString;
            return uriBuilder.Uri;
        }

        private static JsonSerializerSettings MicrosoftDateFormatSettings
        {
            get
            {
                return new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };
            }
        }
        private void addHeaders()
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }

    public enum ApiType
    {
        vehicles,
        quickQuote
    }
}