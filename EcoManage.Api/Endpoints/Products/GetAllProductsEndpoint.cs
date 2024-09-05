using EcoManage.Api.Common.Api;
using EcoManage.Domain;
using EcoManage.Domain.Entities;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Product;
using EcoManage.Domain.Responses;
using Microsoft.AspNetCore.Mvc;

namespace EcoManage.Api.Endpoints.Products;

public class GetAllProductsEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/",HandleAsync)
            .WithName("Products: Get All Products Actives")
            .WithSummary("Obtem todos produtos ativos")
            .WithOrder(2)
            .Produces<PagedResponse<List<Product>?>>();
    private static async Task<IResult> HandleAsync(IProductHandler handler,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetAllProductsRequest() {PageNumber = pageNumber,PageSize = pageSize};

        var result = await handler.GetAllAsync(request);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}