using EcoManage.Api.Common.Api;
using EcoManage.Domain.Entities;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Supplier;
using EcoManage.Domain.Responses;

namespace EcoManage.Api.Endpoints.Suppliers;

public class DeleteSupplierEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id:long}", HandleAsync)
            .WithName("Supplier: Delete")
            .WithSummary("Excluí um fornecedor existente")
            .Produces<Response<Supplier?>>();

    private static async Task<IResult> HandleAsync(ISupplierHandler handler, long id)
    {
        var request = new DeleteSupplierRequest()
        {
            Id = id
        };

        var result = await handler.DeleteAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    } 
}