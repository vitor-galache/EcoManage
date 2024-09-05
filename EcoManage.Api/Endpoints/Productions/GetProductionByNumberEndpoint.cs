using EcoManage.Api.Common.Api;
using EcoManage.Domain.Entities;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Production;
using EcoManage.Domain.Responses;

namespace EcoManage.Api.Endpoints.Productions;

public class GetProductionByNumberEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{number}", HandleAsync)
            .WithName("Productions: Get By Number")
            .WithSummary("Obtem uma produção pelo número")
            .WithOrder(2)
            .Produces<Response<Production?>>();
    
    private static async Task<IResult> HandleAsync(IProductionHandler handler,string number)
    {
        var request = new GetProductionByNumberRequest { Number = number};

        var result = await handler.GetByNumberAsync(request);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}