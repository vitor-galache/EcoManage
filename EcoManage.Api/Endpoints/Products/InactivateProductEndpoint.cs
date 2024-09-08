using EcoManage.Api.Common.Api;
using EcoManage.Domain.Entities;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Product;
using EcoManage.Domain.Responses;

namespace EcoManage.Api.Endpoints.Products;

public class InactivateProductEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}/inactivate", HandleAsync)
            .WithName("Products: Inactivate")
            .WithSummary("Inativa um produto cadastrado")
            .WithOrder(6)
            .Produces<Response<Product?>>();
    private static async Task<IResult> HandleAsync(IProductHandler handler,long id)
    {
        var request = new InactivateProductRequest {Id = id};

        var result = await handler.InactiveAsync(request);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}