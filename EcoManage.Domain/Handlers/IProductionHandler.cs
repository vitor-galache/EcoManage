using EcoManage.Domain.Common;
using EcoManage.Domain.Entities;
using EcoManage.Domain.Requests.Production;
using EcoManage.Domain.Responses;

namespace EcoManage.Domain.Handlers;

public interface IProductionHandler
{
    Task<Response<Production?>> CreateProductionProgrammedAsync(CreateProductionProgrammedRequest request);
    Task<Response<Production?>> CreateProductionUnexpectedAsync(CreateProductionUnexpectedRequest request);
    Task<Response<Production?>> CancelAsync(CancelProductionRequest request);
    Task<Response<Production?>> GetByIdAsync(GetProductionByIdRequest request);
    Task<Response<Production?>> GetByNumberAsync(GetProductionByNumberRequest request);
    Task<Response<Production?>> ToHarvestAsync(UpdateProductionToHarvestRequest request);
    Task<Response<Production?>> UpdateToCultivationAsync(UpdateProductionToCultivationRequest request);
    
    Task<PagedResponse<List<Production>?>> GetAllInCultivation(GetAllProductionsInCultivationRequest request);

    Task<Response<Production?>> FinishAsync(FinishProductionRequest request);
}