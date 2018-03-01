using BusinessLocator.Shared.Models;
using ModernHttpClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Plugin.Connectivity;
using Plugin.Settings;
using System.Net.Http.Headers;
using Polly;

namespace BusinessLocator.Shared.Service
{
    public class ServiceApi : ServiceApiBase
    {

        #region Login / Registration

        public async Task<AccessTokenResponse> Login(string username, string password)
        {
            AccessTokenResponse result = null;
            HttpClient client = new HttpClient(new NativeMessageHandler()) { BaseAddress = new Uri(APIURL) };

            var vals = new List<KeyValuePair<string, string>>();
            vals.Add(new KeyValuePair<string, string>("username", username));
            vals.Add(new KeyValuePair<string, string>("password", password));
            vals.Add(new KeyValuePair<string, string>("grant_type", "password"));
            vals.Add(new KeyValuePair<string, string>("SiteID", GlobalConfiguration.SiteId.ToString()));

            if(CrossConnectivity.Current.IsConnected)
            {
                var call = client.PostAsync(APIURL + "/token", new FormUrlEncodedContent(vals));
                var message = await Policy
                    .Handle<WebException>().Or<IOException>()
                    .WaitAndRetryAsync(retryCount: 2, sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)))
                    .ExecuteAsync(async () => await call);

                string content = await message.Content.ReadAsStringAsync();

                if(!message.IsSuccessStatusCode)
                {
                    var error = JsonConvert.DeserializeObject<JObject>(content);
                    throw new WebException(error["error_description"].ToString());
                }
                result = JsonConvert.DeserializeObject<AccessTokenResponse>(content);
                LocalStorage.SaveLogin(result);
            }
            else
            {
                throw new Exception("No internert connection");
            }

            if(result == null)
            {
                throw new NullReferenceException("Results should not be null");
            }

            return result;
        }
       
        public async Task<JObject> Register(string username, string email, string mobilenumber, string password, string role, double lat, double lng)
        {
            HttpClient client = new HttpClient(new NativeMessageHandler()) { BaseAddress = new Uri(APIURL) };

            var user = new UserRegistrationBindingModel();
            user.SiteId = GlobalConfiguration.SiteId;
            user.DisplayName = username;
            user.Email = email;
            user.PhoneNumber = mobilenumber;
            user.Password = password;
            user.UserRole = role;
            user.Lattitude = lat;
            user.Longitude = lng;

            var result = JsonConvert.SerializeObject(user);
            var content = new StringContent(result, Encoding.UTF8, "application/json");

            if(CrossConnectivity.Current.IsConnected)
            {
                var call = client.PostAsync(APIURL + "/api/Account/Register", content);

                var message = await Policy
                    .Handle<WebException>().Or<IOException>()
                    .WaitAndRetryAsync(retryCount: 2, sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)))
                    .ExecuteAsync(async () => await call);

                string data = await message.Content.ReadAsStringAsync();
                if(!message.IsSuccessStatusCode)
                {
                    var error = JsonConvert.DeserializeObject<JObject>(data);
                    throw new WebException(error["Message"].ToString());
                }
                var success = JsonConvert.DeserializeObject<JObject>(data);
                return success;
            }
            else if(result == null)
            {
                throw new NullReferenceException("Results should not be null");
            }
            else
            {
                throw new Exception("No internert connection");
            }
        }

        #endregion

       
        #region Profile

        public async Task<UserProfileModel> GetUserProfile()
        {
            return await Get<UserProfileModel>("/api/User/GetProfile/", new Dictionary<string, object>());
        }

        #endregion


        #region Location 

        public async Task<ResponseWrapper<UserProfileModel>> GetUserLocation(double lat, double lng, string search = null, string role = null)
        {
            var url = "/api/User/GetUserByLocation/" + lat + "/" + lng + "/" + GlobalConfiguration.SiteId + "/1/10/" + search + "/" + role;
            return await Get<ResponseWrapper<UserProfileModel>>(url, new Dictionary<string, object>());
        }

        #endregion

    }
}
    