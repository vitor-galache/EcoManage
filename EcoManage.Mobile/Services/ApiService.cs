using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EcoManage.Mobile.Services
{
    public class ApiService
    {
        private static readonly Lazy<ApiService> instance = new Lazy<ApiService>(() => new ApiService());
        private HttpClient client;
        private CookieContainer cookieContainer;

        private ApiService()
        {
            cookieContainer = new CookieContainer();
            var handler = new HttpClientHandler() { CookieContainer = cookieContainer };
            client = new HttpClient(handler) { BaseAddress = new Uri("http://192.168.15.8:5017") };
        }

        public static ApiService Instance => instance.Value;
        public HttpClient Client => client;
    }
}
