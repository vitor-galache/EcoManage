using EcoManage.Api.Common.Api;
using EcoManage.Domain.Entities;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Product;
using EcoManage.Domain.Responses;

namespace EcoManage.Api.Endpoints.Products;

public class GetProductByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
            .WithName("Products : Get By Id")
            .WithSummary("Obtem um produto pelo id")
            .WithOrder(3)
            .Produces<Response<Product?>>();
    
    private static async Task<IResult> HandleAsync(IProductHandler handler, long id)
    {
        var request = new GetProductByIdRequest { Id = id };

        var result = await handler.GetByIdAsync(request);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}