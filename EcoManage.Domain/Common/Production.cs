using EcoManage.Domain.Entities;
using EcoManage.Domain.Enums;

namespace EcoManage.Domain.Common;

public abstract class Production
{
    public long Id { get; init; }
    public string Number { get; init; } = Guid.NewGuid().ToString("N")[..8];
    public string Title { get; protected set; } = string.Empty;
    public EProductionStatus Status { get; protected set; } = EProductionStatus.Planting;

    public EHarvestType HarvestType { get; protected set; }  
    
    public DateTime StartDate { get; init; } = DateTime.Now;
    
    public DateTime? EndDate { get; protected set; }
    
    public long ProductId { get; protected set; }
    public Product Product { get; protected set; } = null!;

    public decimal QuantityInKg { get; protected set; }

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