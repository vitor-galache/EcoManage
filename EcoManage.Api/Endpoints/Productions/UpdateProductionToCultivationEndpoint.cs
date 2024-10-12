using EcoManage.Api.Common.Api;
using EcoManage.Domain.Entities.Productions;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Production;
using EcoManage.Domain.Responses;

namespace EcoManage.Api.Endpoints.Productions;

public class UpdateProductionToCultivationEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}/to-cultivation", HandleAsync)
            .WithName("Productions: To Cultivation")
            .WithSummary("Atualiza o status de uma produção em plantio para em cultivo")
            .WithOrder(5)
            .Produces<Response<Production?>>();

    private static async Task<IResult> HandleAsync(IProductionHandler handler, long id)
    {
        var request = new UpdateProductionToCultivationRequest { Id = id };

        var result = await handler.ToCultivationAsync(request);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}