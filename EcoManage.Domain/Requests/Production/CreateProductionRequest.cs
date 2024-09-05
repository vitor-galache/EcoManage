using EcoManage.Domain.Enums;

namespace EcoManage.Domain.Requests.Production;

public class CreateProductionRequest : Request
{
    public string Title { get; set; } = string.Empty;
    
    public DateTime EndDate { get; set; }

    public EHarvestType HarvestType { get; set; } = EHarvestType.Programmed;
    
    public long ProductId { get; set; }

    public decimal QuantityInKg { get; set; }
}