using EcoManage.Api.Common.Api;
using EcoManage.Api.Endpoints.Suppliers;

namespace EcoManage.Api.Endpoints;

public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("");
        
        endpoints.MapGroup("/")
            .WithTags("HealthCheck")
            .MapGet("/", () => new { message = "OK" });


        app.MapGroup("v1/suppliers")
            .WithTags("Suppliers")
            .MapEndpoint<CreateSupplierEndpoint>()
            .MapEndpoint<GetSupplierByIdEndpoint>()
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