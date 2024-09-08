using EcoManage.Api.Common.Api;
using EcoManage.Domain.Common;
using EcoManage.Domain.Entities;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Production;
using EcoManage.Domain.Responses;

namespace EcoManage.Api.Endpoints.Productions;

public class CreateProductionProgrammedEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/programmed", HandleAsync)
            .WithName("Productions: Create Production Programmed")
            .WithSummary("Cadastra uma nova produção programada (Colheita Agendada)")
            .WithOrder(1)
            .Produces<Response<Production?>>();

    private static async Task<IResult> HandleAsync(IProductionHandler handler, CreateProductionProgrammedRequest request)
    {
        var result = await handler.CreateProductionProgrammedAsync(request);
        return result.IsSuccess
            ? TypedResults.Created($"v1/productions/{result.Data?.Id}", result)
            : TypedResults.BadRequest(result);
    }
}