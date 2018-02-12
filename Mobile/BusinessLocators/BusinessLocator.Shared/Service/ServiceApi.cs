using BusinessLocator.Shared.Models;
using ModernHttpClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BusinessLocator.Shared.Service
{
    public class ServiceApi : ServiceApiBase
    {
        #region Account Login/Regiser
      
        public Task<string> Login(string username, string password)
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

            var stringContent = response.Content.ReadAsStringAsync();
            return stringContent;

        }
       
        public HttpResponseMessage Register(string username, string email, string mobilenumber, string password, string role)
        {
           
            HttpClient client = new HttpClient(new NativeMessageHandler()) { BaseAddress = new Uri(APIURL) };

            var vals = new List<KeyValuePair<string, string>>();
            vals.Add(new KeyValuePair<string, string>("SiteID", "1"));
            vals.Add(new KeyValuePair<string, string>("DisplayName", username));
            vals.Add(new KeyValuePair<string, string>("FirstName", username));
            vals.Add(new KeyValuePair<string, string>("LastName", "patel"));
            vals.Add(new KeyValuePair<string, string>("Address1", "songhar"));
            vals.Add(new KeyValuePair<string, string>("Address2", "Kamrej"));
            vals.Add(new KeyValuePair<string, string>("City", "Surat"));
            vals.Add(new KeyValuePair<string, string>("State", "Gujarat"));
            vals.Add(new KeyValuePair<string, string>("ZipCode", "394670"));
            vals.Add(new KeyValuePair<string, string>("PhoneNumber", mobilenumber));
            vals.Add(new KeyValuePair<string, string>("Email", email));
            vals.Add(new KeyValuePair<string, string>("WebSite", "www.gmail.com"));
            vals.Add(new KeyValuePair<string, string>("Description","Testing Demo"));
            vals.Add(new KeyValuePair<string, string>("Image", "abc"));
            vals.Add(new KeyValuePair<string, string>("UserRole", role));
            vals.Add(new KeyValuePair<string, string>("RoleIcon", "abc"));
            vals.Add(new KeyValuePair<string, string>("Password", password));
            vals.Add(new KeyValuePair<string, string>("Longitude", "21.166359"));
            vals.Add(new KeyValuePair<string, string>("Lattitude", "73.5645054"));

            var response = client.PostAsync(APIURL + "/api/Account/Register", new FormUrlEncodedContent(vals)).Result;

            //var stringContent = response.Content.ReadAsStringAsync();
            //return stringContent;
            return response;
        }

     


        #endregion
    }
}
