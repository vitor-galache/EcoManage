using EcoManage.Api.Common.Api;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Product;

namespace EcoManage.Api.Endpoints.Products;

public class UpdateProductEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}",HandleAsync)
            .WithName("Products: Update Product")
            .WithSummary("Atualiza informações de um produto")
            .WithOrder(4);
    
    private static async Task<IResult> HandleAsync(IProductHandler handler,UpdateProductRequest request,long id)
    {
        request.Id = id;
        var result = await handler.UpdateAsync(request);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}