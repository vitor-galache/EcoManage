using EcoManage.Api.Common.Api;
using EcoManage.Domain.Common;
using EcoManage.Domain.Entities;
using EcoManage.Domain.Entities.Productions;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Production;
using EcoManage.Domain.Responses;

namespace EcoManage.Api.Endpoints.Productions;

public class CancelProductionEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}/cancel", HandleAsync)
            .WithName("Productions: Cancel (CropLoss)")
            .WithSummary("Cancelar uma produção por quebra")
            .WithOrder(8)
            .Produces<Response<Production?>>();
    private static async Task<IResult> HandleAsync(IProductionHandler handler,long id)
    {
        var request = new CancelProductionRequest() { Id = id};

        var result = await handler.CancelAsync(request);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}