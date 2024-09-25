using EcoManage.Api.Common.Api;
using EcoManage.Domain.Common;
using EcoManage.Domain.Entities;
using EcoManage.Domain.Entities.Productions;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Production;
using EcoManage.Domain.Responses;

namespace EcoManage.Api.Endpoints.Productions;

public class FinishProductionEndpoint: IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}/finish", HandleAsync)
            .WithName("Productions: Finish")
            .WithSummary("Finaliza uma produção")
            .WithOrder(7)
            .Produces<Response<Production?>>();
    private static async Task<IResult> HandleAsync(IProductionHandler handler,long id)
    {
        var request = new FinishProductionRequest { Id = id};

        var result = await handler.FinishAsync(request);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}