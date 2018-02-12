using ModernHttpClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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

    }
}
