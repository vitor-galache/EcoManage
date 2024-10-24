using EcoManage.Api.Common.Api;
using EcoManage.Persistence.Models;
using Microsoft.AspNetCore.Identity;

namespace EcoManage.Api.Endpoints.Identity;

public class LogoutEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/logout",HandleAsync).RequireAuthorization();

    private static async Task<IResult> HandleAsync(SignInManager<User> user)
    {
        await user.SignOutAsync();
        return Results.Ok();
    }
}