using EcoManage.Api.Common.Api;
using EcoManage.Domain.Entities;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Product;
using EcoManage.Domain.Responses;

namespace EcoManage.Api.Endpoints.Products;

public class GetProductBySlugEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{slug}", HandleAsync)
            .WithName("Products : Get By Slug")
            .WithSummary("Obtem um produto pelo slug")
            .WithOrder(3)
            .Produces<Response<Product?>>();
    
    private static async Task<IResult> HandleAsync(IProductHandler handler, string slug)
    {
        var request = new GetProductBySlugRequest { Slug = slug };

        var result = await handler.GetBySlugAsync(request);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}