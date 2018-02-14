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

namespace BusinessLocator.Shared.Service
{
    public class ServiceApi : ServiceApiBase
    {
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

            vals.Add(new KeyValuePair<string, string>("DisplayName", username));
            vals.Add(new KeyValuePair<string, string>("Email", email));
            vals.Add(new KeyValuePair<string, string>("PhoneNumber", mobilenumber));
            vals.Add(new KeyValuePair<string, string>("Password", password));
            vals.Add(new KeyValuePair<string, string>("UserRole", role));
            vals.Add(new KeyValuePair<string, string>("Longitude", latitude.ToString()));
            vals.Add(new KeyValuePair<string, string>("Lattitude", longitude.ToString()));

            var response = client.PostAsync(APIURL + "/api/Account/Register", new FormUrlEncodedContent(vals)).Result;
            return response;

            //var stringContent = response.Content.ReadAsStringAsync();
            //return stringContent;
        }

     
    }
}
