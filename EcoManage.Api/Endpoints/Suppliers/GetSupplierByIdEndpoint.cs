using EcoManage.Api.Common.Api;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Supplier;
using EcoManage.Domain.Responses;

namespace EcoManage.Api.Endpoints.Suppliers;

public class GetSupplierByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("{id:long}", HandleAsync)
            .WithName("Supplier: Get By Id")
            .WithSummary("Obtem um fornecedor pelo ID")
            .Produces<Response<object?>>();

    private static async Task<IResult> HandleAsync(ISupplierHandler handler, long id)
    {
        var request = new GetSupplierByIdRequest()
        {
            Id = id
        };

        var result = await handler.GetByIdAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}