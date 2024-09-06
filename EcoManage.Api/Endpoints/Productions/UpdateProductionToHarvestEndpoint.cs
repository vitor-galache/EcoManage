using EcoManage.Api.Common.Api;
using EcoManage.Domain.Entities;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Production;
using EcoManage.Domain.Responses;

namespace EcoManage.Api.Endpoints.Productions;

public class UpdateProductionToHarvestEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}/to-harvest", HandleAsync)
            .WithName("Productions: To Harvest")
            .WithSummary("Atualiza o status de uma produção em cultivo para colheita")
            .WithOrder(6)
            .Produces<Response<Production?>>();
    private static async Task<IResult> HandleAsync(IProductionHandler handler,long id)
    {
        var request = new UpdateProductionToHarvestRequest{Id = id};

        var result = await handler.ToHarvestAsync(request);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}