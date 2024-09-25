using EcoManage.Domain.Entities.Reports;
using EcoManage.Domain.Requests.Reports;
using EcoManage.Domain.Responses;

namespace EcoManage.Domain.Handlers;

public interface IReportHandler
{
    Task<Response<List<ProductionsByPeriod>?>> GetProductionsByPeriodAsync(GetProductionsByPeriodRequest request);
    Task<Response<List<TotalProducts>?>> GetTotalProductsAsync(GetTotalProductsRequest request);
}