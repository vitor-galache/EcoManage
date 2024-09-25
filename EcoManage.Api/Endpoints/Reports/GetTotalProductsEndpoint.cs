using EcoManage.Api.Common.Api;
using EcoManage.Domain.Entities.Reports;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Reports;
using EcoManage.Domain.Responses;

namespace EcoManage.Api.Endpoints.Reports;

public class GetTotalProductsEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/total-products", HandleAsync)
            .WithName("Reports: Get Total Products")
            .WithSummary("Obtem todos produtos e quantidade total produzida")
            .Produces<Response<List<TotalProducts>?>>();
    private static async Task<IResult> HandleAsync(IReportHandler handler)
    {
        var request = new GetTotalProductsRequest();
        var result = await handler.GetTotalProductsAsync(request);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}