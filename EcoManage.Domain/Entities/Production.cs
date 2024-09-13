using System.Text.Json.Serialization;
using EcoManage.Domain.Enums;

namespace EcoManage.Domain.Entities;
public class Production 
{
    [JsonConstructor]
    private Production(string title,Product product,long productId,decimal quantityInKg,DateTime? endDate,DateTime startDate, EHarvestType harvestType,EProductionStatus status)
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

    public Production(string title,Product product,decimal quantityInKg,DateTime? endDate)
    {
        Title = title;
        Product = product;
        QuantityInKg = quantityInKg;
        EndDate = endDate;
        HarvestType = EHarvestType.Programmed;
    }
    
    public Production(string title,Product product,decimal quantityInKg)
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

    public long Id { get; init; }
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