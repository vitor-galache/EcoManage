using EcoManage.Api.Common.Api;
using EcoManage.Domain.Entities;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Supplier;
using EcoManage.Domain.Responses;

namespace EcoManage.Api.Endpoints.Suppliers;

public class CreateSupplierEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("", HandleAsync)
            .WithName("Supplier : Create")
            .WithSummary("Cadastra um novo fornecedor")
            .Produces<Response<Supplier?>>();
    private static async Task<IResult> HandleAsync(ISupplierHandler handler,CreateSupplierRequest request)
    {
        var result = await handler.CreateAsync(request);
        return result.IsSuccess
            ? TypedResults.Created($"/{result.Data?.Id}", result)
            : TypedResults.BadRequest(result);
    } 
}