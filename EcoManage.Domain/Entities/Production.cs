using System.Text.Json.Serialization;
using EcoManage.Domain.Common;
using EcoManage.Domain.Enums;
using Flunt.Validations;

namespace EcoManage.Domain.Entities;

public class Production : Entity
{
    [JsonConstructor]
    private Production(string title, Product product, long productId, decimal quantityInKg, DateTime? endDate,
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

    public Production(string title, Product product, decimal quantityInKg, DateTime? endDate)
    {
        Title = title;
        Product = product;
        QuantityInKg = quantityInKg;
        EndDate = endDate;
        HarvestType = EHarvestType.Programmed;
        AddNotifications(new Contract().Requires().IsTrue(EndDateValidation(EndDate), "Production.EndDate",
            "A data final de uma produção agendada deve estar no futuro"));
    }

    public Production(string title, Product product, decimal quantityInKg)
    {
        Title = title;
        Product = product;
        QuantityInKg = quantityInKg;
        EndDate = null;
        HarvestType = EHarvestType.Unexpected;
    }

    private Production()
    {
    }

    private bool EndDateValidation(DateTime? endDate)
    {
        if (endDate is null)
            return false;
        if (endDate <= DateTime.UtcNow)
            return false;

        return true;
    }

    public string Number { get; init; } = Guid.NewGuid().ToString("N")[..8];
    public string Title { get; private set; } = string.Empty;
    public EProductionStatus Status { get; private set; } = EProductionStatus.Planting;
    public EHarvestType HarvestType { get; private set; }

    public DateTime StartDate { get; init; } = DateTime.UtcNow;

    public DateTime? EndDate { get; private set; }

    public long ProductId { get; private set; }
    public Product Product { get; private set; } = null!;
    public decimal QuantityInKg { get; private set; }

    #region Public Methods

    public void Cancel()
    {
        EndDate = DateTime.Now;
        Status = EProductionStatus.CropLoss;
    }

    public void ToCultivation()
    {
        Status = EProductionStatus.Cultivation;
    }

    public void ToHarvesting()
    {
        Status = EProductionStatus.Harvesting;
    }

    public void Finish()
    {
        EndDate = DateTime.Now;
        Status = EProductionStatus.Finished;
    }

    #endregion
}