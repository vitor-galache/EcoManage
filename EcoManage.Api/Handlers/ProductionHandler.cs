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

    public async Task<Response<Production?>> GetByNumberAsync(GetProductionByNumberRequest request)
    {
        try
        {
            var production = await context.Productions.AsNoTracking().Include(x => x.Product)
                .FirstOrDefaultAsync(x => x.Number == request.Number);

            return production is null
                ? new Response<Production?>(null, 404, "Produção não encontrada")
                : new Response<Production?>(production);
        }
        catch
        {
            return new Response<Production?>(null, 400, "Falha ao obter produção");
        }
    }

    public async Task<Response<Production?>> ToHarvestAsync(UpdateProductionToHarvestRequest request)
    {
        Production? production;
        try
        {
            production = await context.Productions.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (production is null)
                return new Response<Production?>(null, 404, "Produção não encontrada");
            
            switch (production.Status)
            {
                case EProductionStatus.Planting:
                    return new Response<Production?>(production,400,"Está produção esta na fase de plantio e não pode ir para colheita");

                case EProductionStatus.Cultivation:
                    break;

                case EProductionStatus.Harvesting:
                    return new Response<Production?>(production,400,"Esta produção já está na fase de colheita");

                case EProductionStatus.CropLoss:
                    return new Response<Production?>(production, 400, "Esta produção já foi cancelada");

                case EProductionStatus.Finished:
                    return new Response<Production?>(production, 400,
                        "Está produção já foi finalizada e não pode ser colhida");

                default:
                    return new Response<Production?>(production, 400, "Esta produção não pode ser colhida");
            }
            
            production.ToHarvesting();
            context.Productions.Update(production);
            await context.SaveChangesAsync();
            return new Response<Production?>(production, 200,
                $"Status da Produção {production.Number} atualizado para {production.Status.ToString()}");
        }
        catch
        {
            return new Response<Production?>(null, 500, "Falha ao atualizar status de produção");
        }
    }

    public async Task<Response<Production?>> UpdateToCultivationAsync(UpdateProductionToCultivationRequest request)
    {
        Production? production;
        try
        {
            production = await context.Productions.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (production is null)
                return new Response<Production?>(null, 404, "Produção não encontrada");
            
            switch (production.Status)
            {
                case EProductionStatus.Planting:
                    break;

                case EProductionStatus.Cultivation:
                    return new Response<Production?>(production,400,"Esta produção já está na fase de cultivo");

                case EProductionStatus.Harvesting:
                    return new Response<Production?>(production,400,"Esta produção já está na fase de colheita");

                case EProductionStatus.CropLoss:
                    return new Response<Production?>(production, 400, "Esta produção já foi cancelada");

                case EProductionStatus.Finished:
                    return new Response<Production?>(production, 400,
                        "Está produção já foi finalizada");

                default:
                    return new Response<Production?>(production, 400, "Esta produção não pode ir para cultivo");
            }
            
            production.ToCultivation();

            context.Productions.Update(production);
            await context.SaveChangesAsync();
            return new Response<Production?>(production, 200,
                $"Status da Produção {production.Number} atualizado para {production.Status.ToString()}");
        }
        catch
        {
            return new Response<Production?>(null, 500, "Falha ao atualizar status de produção");
        }
    }

    public async Task<PagedResponse<List<Production>?>> GetAllInCultivation(GetAllProductionsInCultivationRequest request)
    {
        try
        {
            var query = context.Productions.AsNoTracking().Include(x => x.Product)
                .Where(x => x.Status == EProductionStatus.Cultivation).OrderBy(x => x.Id);

            var productions = await query.Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            var count = await query.CountAsync();

            return new PagedResponse<List<Production>?>(productions, count, request.PageNumber, request.PageSize);
        }
        catch
        {
            return new PagedResponse<List<Production>?>(null, 500, "Falha ao obter produções em cultivo");
        }
    }

    public async Task<Response<Production?>> FinishAsync(FinishProductionRequest request)
    {
        Production? production;
        try
        {
            production = await context.Productions.FirstOrDefaultAsync(x => x.Id == request.Id);
            
            if (production is null)
                return new Response<Production?>(null, 404, "Produção não encontrada");
            
            switch (production.Status)
            {
                case EProductionStatus.Planting:
                    return new Response<Production?>(production,400,"Esta produção está na fase de plantio e não pode ser finalizada");

                case EProductionStatus.Cultivation:
                    return new Response<Production?>(production,400,"Esta produção está na fase de cultivo e não pode ser finalizada");

                case EProductionStatus.Harvesting:
                    break;

                case EProductionStatus.CropLoss:
                    return new Response<Production?>(production, 400, "Esta produção já foi cancelada e não pode ser finalizada");

                case EProductionStatus.Finished:
                    return new Response<Production?>(production, 400,
                        "Está produção já foi finalizada");

                default:
                    return new Response<Production?>(production, 400, "Esta produção não pode ser finalizada");
            }
            
            production.Finish();
            context.Productions.Update(production);
            await context.SaveChangesAsync();
            return new Response<Production?>(production, 200, $"Produção {production.Number} finalizada com sucesso!");

        }
        catch
        {
            return new Response<Production?>(null, 500, "Falha ao finalizar produção");
        }
    }
}