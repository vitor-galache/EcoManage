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
    }

    private ProductionProgrammed()
    {
    }

    private ProductionProgrammed(string title, Product product, decimal quantityInKg,
        DateTime? endDate)
    {
        Title = title;
        HarvestType = EHarvestType.Programmed;
        EndDate = endDate;
        Product = product;
        QuantityInKg = quantityInKg;
        if (QuantityInKg <= 0)
            AddNotification("Production.QuantityInKg", "A quantidade não pode ser menor que 0");
        if (endDate <= DateTime.UtcNow.AddDays(15))
            AddNotification("", "A produção deve ser agendada no mínimo 15 dias no futuro");
    }

    #region Factories

    public static class Factories
    {
        public static ProductionProgrammed Create(string title, Product product, decimal quantityInKg,
            DateTime? endDate)
        {
            return new ProductionProgrammed(title, product, quantityInKg, endDate);
        }
    }

    #endregion
}