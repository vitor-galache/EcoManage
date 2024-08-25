using EcoManage.Api.Common.Api;
using EcoManage.Api.Endpoints.Identity;
using EcoManage.Api.Endpoints.Suppliers;
using EcoManage.Api.Models;

namespace EcoManage.Api.Endpoints;

public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("");
        
        endpoints.MapGroup("/")
            .WithTags("HealthCheck")
            .MapGet("/", () => new { message = "OK" });



        app.MapGroup("v1/identity")
            .WithTags("Identity")
            .MapIdentityApi<User>();

        app.MapGroup("v1/identity")
            .WithTags("Identity")
            .MapEndpoint<LogoutEndpoint>()
            .MapEndpoint<GetRolesEndpoint>();
        
        app.MapGroup("v1/suppliers")
            .WithTags("Suppliers")
            .RequireAuthorization()
            .MapEndpoint<CreateSupplierEndpoint>()
            .MapEndpoint<GetSupplierByIdEndpoint>()
            .MapEndpoint<GetAllSupplierEndpoint>()
            .MapEndpoint<UpdateSupplierEndpoint>()
            .MapEndpoint<DeleteSupplierEndpoint>();
    }
    
    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint

    {
        TEndpoint.Map(app);
        return app;
    }
}