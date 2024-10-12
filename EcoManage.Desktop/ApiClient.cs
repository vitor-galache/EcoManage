using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EcoManage.Desktop
{
    public class ApiClient
    {
        private static readonly Lazy<ApiClient> instance = new Lazy<ApiClient>(() => new ApiClient());
        private HttpClient client;
        private CookieContainer cookieContainer;

        private ApiClient()
        {
            cookieContainer = new CookieContainer();
            var handler = new HttpClientHandler() { CookieContainer = cookieContainer};
            client = new HttpClient(handler);
        }

        public static ApiClient Instance => instance.Value;
        public HttpClient Client => client;
    }
}
