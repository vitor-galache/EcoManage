using EcoManage.Api.Data;
using EcoManage.Domain.Entities;
using EcoManage.Domain.Enums;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Production;
using EcoManage.Domain.Responses;
using Microsoft.EntityFrameworkCore;

namespace EcoManage.Api.Handlers;

public class ProductionHandler(AppDbContext context) : IProductionHandler
{
    public async Task<Response<Production?>> CreateAsync(CreateProductionRequest request)
    {
        try
        {
            var production =
                new Production(request.Title, request.ProductId, request.QuantityInKg, request.HarvestType);
            await context.Productions.AddAsync(production);
            await context.SaveChangesAsync();
            return new Response<Production?>(production, 201, $"Produção {production.Number} cadastrada com sucesso!");
        }
        catch
        {
            return new Response<Production?>(null, 500, "Erro ao cadastrar produção");
        }
    }

    public async Task<Response<Production?>> CancelAsync(CancelProductionRequest request)
    {
        Production? production;

        try
        {
            production = await context.Productions.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (production is null)
                return new Response<Production?>(null, 404, "Produção não encontrada");
            context.Attach(production);

            switch (production.Status)
            {
                case EProductionStatus.Planting:
                    break;

                case EProductionStatus.Cultivation:
                    break;

                case EProductionStatus.Harvesting:
                    break;

                case EProductionStatus.CropLoss:
                    return new Response<Production?>(production, 400, "Esta produção já foi cancelada");

                case EProductionStatus.Finished:
                    return new Response<Production?>(production, 400,
                        "Está produção já foi finalizada e não pode ser cancelada");

                default:
                    return new Response<Production?>(production, 400, "Esta produção não pode ser cancelada");
            }

            production.Cancel();
            context.Productions.Update(production);
            await context.SaveChangesAsync();
            return new Response<Production?>(production, 200, $"Perda da safra {production.Number} registrada com sucesso!");
        }
        catch
        {
            return new Response<Production?>(null, 500, "Erro ao cancelar produção");
        }

    }

    public Task<Response<Production?>> GetByNumberAsync(GetProductionByNumberRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Response<Production?>> ToHarvestAsync(ToHarvestRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Response<Production?>> UpdateToCultivationAsync(UpdateProductionToCultivationRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResponse<List<Production>?>> GetAllInCultivation(GetAllProductionsInCultivationRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Response<Production?>> FinishAsync(FinishingProductionRequest request)
    {
        throw new NotImplementedException();
    }
}