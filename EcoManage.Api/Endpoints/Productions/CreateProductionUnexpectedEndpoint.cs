using EcoManage.Api.Common.Api;
using EcoManage.Domain.Common;
using EcoManage.Domain.Entities;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Production;
using EcoManage.Domain.Responses;

namespace EcoManage.Api.Endpoints.Productions;
 
public class CreateProductionUnexpectedEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/unexpected", HandleAsync)
            .WithName("Productions: Create Production Unexpected")
            .WithSummary("Cadastra uma nova produção sem data de finalização prevista")
            .WithOrder(2)
            .Produces<Response<Production?>>();

    private static async Task<IResult> HandleAsync(IProductionHandler handler, CreateProductionUnexpectedRequest request)
    {
        var result = await handler.CreateProductionUnexpectedAsync(request);
        return result.IsSuccess
            ? TypedResults.Created($"v1/productions/{result.Data?.Id}", result)
            : TypedResults.BadRequest(result);
    }
}