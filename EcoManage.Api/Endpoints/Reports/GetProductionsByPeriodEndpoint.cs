using EcoManage.Api.Common.Api;
using EcoManage.Domain.Entities.Reports;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Reports;
using EcoManage.Domain.Responses;

namespace EcoManage.Api.Endpoints.Reports;

public class GetProductionsByPeriodEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/productions-by-period",HandleAsync)
            .WithName("Reports: Get Productions By Period")
            .WithSummary("Obtem quantidades de produções em cada mês")
            .Produces<Response<List<ProductionsByPeriod>?>>();
    private static async Task<IResult> HandleAsync(IReportHandler handler)
    {
        var request = new GetProductionsByPeriodRequest();
        var result = await handler.GetProductionsByPeriodAsync(request);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}