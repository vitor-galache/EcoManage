using System.Text.Json.Serialization;
using EcoManage.Domain.Enums;

namespace EcoManage.Domain.Entities.Productions;

public class ProductionUnexpected : Production
{
    public ProductionUnexpected()
    {
        
    }
    [JsonConstructor]
    private ProductionUnexpected(string title, Product product, long productId, decimal quantityInKg, DateTime? endDate,
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
    }
    public static class Factories
    {
        public static ProductionUnexpected Create(string title, Product product, decimal quantityInKg)
        {
            return new ProductionUnexpected
            {
                Title = title,
                HarvestType = EHarvestType.Unexpected,
                EndDate = null,
                Product = product,
                QuantityInKg = quantityInKg
            };
        }
    }
}