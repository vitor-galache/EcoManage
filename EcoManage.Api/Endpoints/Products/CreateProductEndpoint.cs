using EcoManage.Api.Common.Api;
using EcoManage.Domain.Entities;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Product;
using EcoManage.Domain.Responses;

namespace EcoManage.Api.Endpoints.Products;

public class CreateProductEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/",HandleAsync)
            .WithName("Products: Create")
            .WithSummary("Cadastra um novo produto")
            .WithOrder(1)
            .Produces<Response<Product?>>();
    private static async Task<IResult> HandleAsync(CreateProductRequest request,IProductHandler handler)
    {
        
        var result = await handler.CreateAsync(request);
        
        return result.IsSuccess
            ? TypedResults.Created($"v1/products/{result.Data?.Id}",result)
            : TypedResults.BadRequest(result);
    }
}