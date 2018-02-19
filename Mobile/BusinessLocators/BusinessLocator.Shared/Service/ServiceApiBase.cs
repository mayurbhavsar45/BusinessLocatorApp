using ModernHttpClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Plugin.Settings;
using Plugin.Connectivity;
using System.Net;
using System.Net.Http.Headers;
using Polly;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BusinessLocator.Shared.Service
{
    public class ServiceApiBase
    {
        public static string APIURL = "http://blapi.azurewebsites.net";
        protected HttpClient _Client;

        public ServiceApiBase()
        {
            //_apiService = apiService;
            _Client = new HttpClient(new NativeMessageHandler())
            {
                BaseAddress = new Uri(APIURL)
            };
        }
      
        protected async Task Get(string route, Dictionary<string, object> values)
        {
            var accessToken = CrossSettings.Current.GetValueOrDefault("AccessToken", "");
            if (CrossConnectivity.Current.IsConnected)
            {
                HttpClient c = new HttpClient(new NativeMessageHandler()) { BaseAddress = new Uri(APIURL) };
                string queryString = "?";
                foreach (var item in values)
                {
                    if (queryString != "?")
                    {
                        queryString += "&";
                    }
                    queryString += item.Key + "=" + WebUtility.UrlEncode(item.Value.ToString());
                }
                if (!string.IsNullOrEmpty(accessToken))
                {
                    c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
                var t = c.GetAsync(APIURL + route + queryString);
                var message = await Policy
                .Handle<WebException>().Or<IOException>()
                .WaitAndRetryAsync(retryCount: 2, sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)))
                .ExecuteAsync(async () => await t);

                string content = await message.Content.ReadAsStringAsync();
                if (!message.IsSuccessStatusCode)
                {
                    bool status = IsJson(content);
                    if (status)
                    {
                        var error = JsonConvert.DeserializeObject<JObject>(content);

                        try
                        {
                            var err = error["Message"].ToString();
                            throw new WebException(err);
                        }
                        catch (NullReferenceException ex)
                        { }
                    }
                }
                var success = JsonConvert.DeserializeObject<JObject>(content);
            }
            else
            {
                throw new Exception("No internet connection.");
            }
        }

        public static bool IsJson(string input)
        {
            input = input.Trim();
            return input.StartsWith("{", StringComparison.Ordinal) && input.EndsWith("}", StringComparison.Ordinal)
                   || input.StartsWith("[", StringComparison.Ordinal) && input.EndsWith("]", StringComparison.Ordinal);
        }

    }

}
