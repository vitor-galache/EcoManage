using EcoManage.Api.Common.Api;
using EcoManage.Domain.Entities;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Supplier;
using EcoManage.Domain.Responses;

namespace EcoManage.Api.Endpoints.Suppliers;

public class UpdateSupplierEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id:long}", HandleAsync)
            .WithName("Supplier : Update")
            .WithSummary("Atualiza dados de um fornecedor")
            .Produces<Response<Supplier?>>();
    
    private static async Task<IResult> HandleAsync(ISupplierHandler handler,UpdateSupplierRequest request,long id)
    {
        request.Id = id;
        
        var result = await handler.UpdateAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    } 
}