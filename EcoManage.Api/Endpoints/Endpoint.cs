using EcoManage.Api.Common.Api;
using EcoManage.Api.Endpoints.Identity;
using EcoManage.Api.Endpoints.Productions;
using EcoManage.Api.Endpoints.Products;
using EcoManage.Api.Endpoints.Reports;
using EcoManage.Api.Endpoints.Suppliers;
using EcoManage.Api.Models;
using EcoManage.Domain.Requests.Production;

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
            //.RequireAuthorization()
            .MapEndpoint<CreateSupplierEndpoint>()
            .MapEndpoint<GetSupplierByIdEndpoint>()
            .MapEndpoint<GetAllSupplierEndpoint>()
            .MapEndpoint<UpdateSupplierEndpoint>()
            .MapEndpoint<DeleteSupplierEndpoint>();
        
        app.MapGroup("v1/products")
            .WithTags("Products")
            .MapEndpoint<CreateProductEndpoint>()
            .MapEndpoint<GetAllProductsEndpoint>()
            .MapEndpoint<GetProductByIdEndpoint>()
            .MapEndpoint<GetProductBySlugEndpoint>()
            .MapEndpoint<UpdateProductEndpoint>()
            .MapEndpoint<InactivateProductEndpoint>();

        app.MapGroup("v1/productions")
            .WithTags("Productions")
            .MapEndpoint<CreateProductionEndpoint>()
            .MapEndpoint<GetProductionByIdEndpoint>()
            .MapEndpoint<GetProductionByNumberEndpoint>()
            .MapEndpoint<GetAllProductionsEndpoint>()
            .MapEndpoint<UpdateProductionToCultivationEndpoint>()
            .MapEndpoint<UpdateProductionToHarvestEndpoint>()
            .MapEndpoint<FinishProductionEndpoint>()
            .MapEndpoint<CancelProductionEndpoint>();

        app.MapGroup("v1/reports")
            .WithTags("Reports")
            .MapEndpoint<GetProductionsByPeriodEndpoint>()
            .MapEndpoint<GetTotalProductsEndpoint>();
    }
    
    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint

    {
        TEndpoint.Map(app);
        return app;
    }
}