using System.Net.Http.Json;
using System.Text;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Account;
using EcoManage.Domain.Responses;

namespace EcoManage.Web.Handlers;

public class AccountHandler(IHttpClientFactory httpClientFactory) : IAccountHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);
    
    public async Task<Response<string>> LoginAsync(LoginRequest request)
    {
        var result = await _client.PostAsJsonAsync("v1/identity/login?useCookies=true", request);
        return result.IsSuccessStatusCode
            ? new Response<string>("Login realizado com sucesso", 200, "Login realizado")
            : new Response<string>(null, (int)result.StatusCode, "Não foi possível realizar o login");
    }

    public async Task LogoutAsync()
    {
        var emptyContent = new StringContent("{}",Encoding.UTF8,"application/json");
        await _client.PostAsJsonAsync("v1/identity/logout", emptyContent);
    }
}