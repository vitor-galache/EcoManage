using System.Text.Json.Serialization;
using EcoManage.Domain.Enums;

namespace EcoManage.Domain.Entities.Productions;

public class ProductionProgrammed : Production
{
    [JsonConstructor]
    private ProductionProgrammed(string title, Product product, long productId, decimal quantityInKg, DateTime? endDate,
        DateTime startDate, EHarvestType harvestType, EProductionStatus status)
    {
        Title = title;
        Product = product;
        ProductId = productId;
        QuantityInKg = quantityInKg;
        StartDate = startDate;
        EndDate = endDate;
        Status = status;
        HarvestType = harvestType;
        if (endDate >= DateTime.UtcNow)
            AddNotification("Production.EndDate","A data prevista para conclusão não pode estar no futuro");
    }

    private ProductionProgrammed()
    {
        
    }

    public static class Factories
    {
        public static ProductionProgrammed Create(string title, Product product, decimal quantityInKg,
            DateTime? endDate)
        {
            return new ProductionProgrammed
            {
                Title = title,
                HarvestType = EHarvestType.Programmed,
                EndDate = endDate,
                Product = product,
                QuantityInKg = quantityInKg
            };
        }
    }
}