using System.Text.Json.Serialization;
using EcoManage.Domain.Common;
using EcoManage.Domain.Enums;

namespace EcoManage.Domain.Entities.Productions;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "HarvestType")]
[JsonDerivedType(typeof(ProductionProgrammed),"Programmed")]
[JsonDerivedType(typeof(ProductionUnexpected),"Unexpected")]
public abstract class Production : Entity
{
    #region Constructors

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
    
    //EF Constructor
    protected Production()
    {
        
    }

    #endregion
    
    #region Properties
    public string Number { get; init; } = Guid.NewGuid().ToString("N")[..8];
    public string Title { get; protected set; } = string.Empty;
    public EProductionStatus Status { get; protected set; } = EProductionStatus.Planting;
    public EHarvestType HarvestType { get; protected set; }
    public DateTime StartDate { get; init; } = DateTime.UtcNow;

    public DateTime? EndDate { get; protected set; }

    public long ProductId { get; protected set; }
    public Product Product { get; protected set; } = null!;
    public decimal QuantityInKg { get; protected set; }
    #endregion

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