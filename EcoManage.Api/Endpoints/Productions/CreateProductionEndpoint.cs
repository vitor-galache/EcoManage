using EcoManage.Api.Common.Api;
using EcoManage.Domain.Entities.Productions;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Production;
using EcoManage.Domain.Responses;

namespace EcoManage.Api.Endpoints.Productions;

public class CreateProductionEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Productions: Create Production")
            .WithSummary("Cadastra uma nova produção")
            .WithOrder(1)
            .Produces<Response<Production?>>();

    private static async Task<IResult> HandleAsync(IProductionHandler handler, CreateProductionRequest request)
    {
        var result = await handler.CreateProductionAsync(request);
        return result.IsSuccess
            ? TypedResults.Created($"v1/productions/{result.Data?.Id}", result)
            : TypedResults.BadRequest(result);
    }
}