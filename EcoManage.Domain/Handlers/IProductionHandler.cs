using EcoManage.Domain.Entities;
using EcoManage.Domain.Requests.Production;
using EcoManage.Domain.Responses;

namespace EcoManage.Domain.Handlers;

public interface IProductionHandler
{
    Task<Response<Production?>> CreateAsync(CreateProductionRequest request);
    Task<Response<Production?>> CancelAsync(CancelProductionRequest request);
    Task<Response<Production?>> GetByNumberAsync(GetProductionByNumberRequest request);
    Task<Response<Production?>> ToHarvestAsync(ToHarvestRequest request);
    Task<Response<Production?>> UpdateToCultivationAsync(UpdateProductionToCultivationRequest request);
    
    Task<PagedResponse<List<Production>?>> GetAllInCultivation(GetAllProductionsInCultivationRequest request);

    Task<Response<Production?>> FinishAsync(FinishingProductionRequest request);
}