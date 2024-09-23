using EcoManage.Api.Data;
using EcoManage.Domain.Entities.Reports;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Reports;
using EcoManage.Domain.Responses;
using Microsoft.EntityFrameworkCore;

namespace EcoManage.Api.Handlers;

public class ReportHandler(AppDbContext context) : IReportHandler
{
    public async Task<Response<List<ProductionsByPeriod>?>> GetProductionsByPeriodAsync(GetProductionsByPeriodRequest request)
    {
        try
        {
            var data = await context.ProductionsByPeriod.AsNoTracking().OrderByDescending(x=>x.Year)
                .ThenBy(x=>x.Month)
                .ToListAsync();

            return new Response<List<ProductionsByPeriod>?>(data);
        }
        catch (Exception)
        {
            return new Response<List<ProductionsByPeriod>?>(null, 500, "Ocorreu um erro ao obter as produções");
        }
    }

    public async Task<Response<List<TotalProducts>?>> GetTotalProductsAsync(GetTotalProductsRequest request)
    {
        try
        {
            var data = await context.TotalProducts.AsNoTracking().OrderByDescending(x => x.TotalProduced).ThenBy(x => x.Product)
                .ToListAsync();

            return new Response<List<TotalProducts>?>(data);
        }
        catch (Exception)
        {
            return new Response<List<TotalProducts>?>(null, 500, "Ocorreu um erro ao obter produtos mais produzidos");
        }
    }
}