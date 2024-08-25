using EcoManage.Domain.Requests.Account;
using EcoManage.Domain.Responses;

namespace EcoManage.Domain.Handlers;

public interface IAccountHandler
{
    Task<Response<string>> LoginAsync(LoginRequest request);
    Task LogoutAsync();
}