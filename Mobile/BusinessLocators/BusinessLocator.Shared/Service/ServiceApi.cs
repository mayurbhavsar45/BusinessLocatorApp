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

namespace BusinessLocator.Shared.Service
{
    public class ServiceApi : ServiceApiBase
    {
        #region Account Login/Regiser

        public HttpResponseMessage Login(string username, string password)
        {
            HttpClient client = new HttpClient(new NativeMessageHandler())
            {
                BaseAddress = new Uri(APIURL)
            };

            var vals = new List<KeyValuePair<string, string>>();
            vals.Add(new KeyValuePair<string, string>("grant_type", "password"));
            vals.Add(new KeyValuePair<string, string>("username", username));
            vals.Add(new KeyValuePair<string, string>("password", password));


            var response = client.PostAsync(APIURL + "/token", new FormUrlEncodedContent(vals)).Result;

            return response;

        }

        public HttpResponseMessage Register(string username, string email, string mobilenumber, string password, string role, double latitude, double longitude)
        {

            HttpClient client = new HttpClient(new NativeMessageHandler())
            {
                BaseAddress = new Uri(APIURL)
            };

            var vals = new List<KeyValuePair<string, string>>();
            vals.Add(new KeyValuePair<string, string>("SiteID", "1"));
            vals.Add(new KeyValuePair<string, string>("DisplayName", username));
            vals.Add(new KeyValuePair<string, string>("FirstName", username));
            vals.Add(new KeyValuePair<string, string>("PhoneNumber", mobilenumber));
            vals.Add(new KeyValuePair<string, string>("Email", email));
            vals.Add(new KeyValuePair<string, string>("UserRole", role));
            vals.Add(new KeyValuePair<string, string>("Password", password));
            vals.Add(new KeyValuePair<string, string>("Longitude", latitude.ToString()));
            vals.Add(new KeyValuePair<string, string>("Lattitude", longitude.ToString()));

            var response = client.PostAsync(APIURL + "/api/Account/Register", new FormUrlEncodedContent(vals)).Result;
            return response;
        }

        #endregion

        #region Profile
        public HttpResponseMessage GetConsumerProfile()
        {
            HttpClient client = new HttpClient(new NativeMessageHandler())
            {
                BaseAddress = new Uri(APIURL)
            };

            var access_token = CrossSettings.Current.GetValueOrDefault("AccessToken", "");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token);
            var response = client.GetAsync(APIURL + "/api/User/GetProfile").Result;

            return response;
        }
        #endregion

        #region Location 
        public List<MapListView> GetLocation(string lat, string lng, string role)
        {
            List<MapListView> lst=new List<MapListView>();
            HttpClient client = new HttpClient(new NativeMessageHandler())
            {
                BaseAddress = new Uri(APIURL)
            };
            int startindex = 1;
            int endindex = 10;

            Dictionary<string, object> test = new Dictionary<string, object>
            {

                { "Lattitude", lat },
                { "Longitude", lng },
                { "role", role },
                {"startindex",startindex },
                {"endindex",endindex }

            };
            string latitude = lat.ToString();
            var access_token = CrossSettings.Current.GetValueOrDefault("AccessToken", "");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token);
            //client.GetAsync(APIURL + "/api/User/GetUserByLocation/21.17024/72.831062/Provider/1/10",);

            var response = client.GetAsync(APIURL + "/api/User/GetUserByLocation/"+ lat +"/"+ lng +"/"+ role +"/1/10").Result;
           var s= response.Content.ReadAsStringAsync();
            var i = JsonConvert.DeserializeObject<MapListView>(s.Result);
            lst= JsonConvert.DeserializeObject<List<MapListView>>(s.Result);
            return lst;


        }
        #endregion

    }
}
