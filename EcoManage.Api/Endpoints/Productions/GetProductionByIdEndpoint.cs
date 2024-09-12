using EcoManage.Api.Common.Api;
using EcoManage.Domain.Common;
using EcoManage.Domain.Entities;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Production;
using EcoManage.Domain.Responses;

namespace EcoManage.Api.Endpoints.Productions;

public class GetProductionByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id:long}", HandleAsync)
            .WithName("Productions: Get By Id")
            .WithSummary("Obtem uma produção pelo id")
            .WithOrder(2)
            .Produces<Response<Production?>>();
    
    private static async Task<IResult> HandleAsync(IProductionHandler handler,long id)
    {
        var request = new GetProductionByIdRequest{ Id = id};

        var result = await handler.GetByIdAsync(request);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}