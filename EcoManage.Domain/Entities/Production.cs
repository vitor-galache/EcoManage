using EcoManage.Domain.Enums;

namespace EcoManage.Domain.Entities;

public class Production
{


    public Production(string title,long productId,decimal quantityInKg,EHarvestType harvestType = EHarvestType.Programmed)
    {
        Title = title;
        ProductId = productId;
        QuantityInKg = quantityInKg;
        HarvestType = harvestType;
    }
    public long Id { get; init; }
    public string Number { get; init; } = Guid.NewGuid().ToString("N")[..8];
    public string Title { get; private set; } 
    public EProductionStatus Status { get; private set; } = EProductionStatus.Planting;

    public EHarvestType HarvestType { get; private set; }  
    
    public DateTime StartDate { get; init; } = DateTime.Now;
    
    public DateTime? EndDate { get; private set; }
    
    public long ProductId { get; private set; }
    public Product Product { get; private set; } = null!;

    public decimal QuantityInKg { get; private set; }


    public void Cancel()
    {
        EndDate = DateTime.Now;
        Status = EProductionStatus.CropLoss;
    }
    
    void ToCultivation()
    {
        Status = EProductionStatus.Cultivation;
    }

    void FinishingProduction()
    {
        EndDate = DateTime.Now;
        Status = EProductionStatus.Finished;
    }
    
}