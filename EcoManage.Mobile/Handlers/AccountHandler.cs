using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Account;
using EcoManage.Domain.Responses;
using EcoManage.Mobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EcoManage.Mobile.Handlers
{
    class AccountHandler : IAccountHandler
    {
        private HttpClient client = ApiService.Instance.Client;

        public async Task<Response<string>> LoginAsync(LoginRequest request)
        {
            var response = await client.PostAsJsonAsync("v1/identity/login?useCookies=true", request);
            if (!response.IsSuccessStatusCode)
            {
                return new Response<string>(null, (int)response.StatusCode, "Não foi possível realizar o login");
            }
            return new Response<string>("Login realizado",200);
        }

        public async Task LogoutAsync()
        {
            var emptyContent = new StringContent("{}", Encoding.UTF8, "application/json");
            await client.PostAsJsonAsync("v1/identity/logout",emptyContent);
        }
    }
}
