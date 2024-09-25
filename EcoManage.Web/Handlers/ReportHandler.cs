using System.Net.Http.Json;
using EcoManage.Domain.Entities.Reports;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Reports;
using EcoManage.Domain.Responses;

namespace EcoManage.Web.Handlers;

public class ReportHandler(IHttpClientFactory httpClientFactory) : IReportHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);
    public async Task<Response<List<ProductionsByPeriod>?>> GetProductionsByPeriodAsync(GetProductionsByPeriodRequest request)
    {
        return await _client.GetFromJsonAsync<Response<List<ProductionsByPeriod>?>>("v1/reports/productions-by-period")
               ?? new Response<List<ProductionsByPeriod>?>(null, 400, "Não foi possível obter as produções");
    }

    public async Task<Response<List<TotalProducts>?>> GetTotalProductsAsync(GetTotalProductsRequest request)
    {
        return await _client.GetFromJsonAsync<Response<List<TotalProducts>?>>("v1/reports/total-products")
               ?? new Response<List<TotalProducts>?>(null, 400, "Não foi possível obter os dados");
    }
}