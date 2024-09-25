using EcoManage.Api.Common.Api;
using EcoManage.Domain;
using EcoManage.Domain.Entities;
using EcoManage.Domain.Entities.Productions;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Production;
using EcoManage.Domain.Responses;
using Microsoft.AspNetCore.Mvc;

namespace EcoManage.Api.Endpoints.Productions;

public class GetAllProductionsEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
            .WithName("Productions: Get All In Cultivation")
            .WithSummary("Obtem todas produções na fase de cultivo")
            .WithOrder(4)
            .Produces<PagedResponse<List<Production>?>>();
    private static async Task<IResult> HandleAsync(IProductionHandler handler,
        [FromQuery]int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery]int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetAllProductionsRequest
        {
            PageNumber = pageNumber,
            PageSize = pageSize
        };

        var result = await handler.GetAllAsync(request);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}