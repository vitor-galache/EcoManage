using System.ComponentModel.DataAnnotations;
using EcoManage.Domain.Enums;

namespace EcoManage.Domain.Requests.Production;

public class CreateProductionRequest : Request
{
    [Required (ErrorMessage = "Titulo obrigatório")]
    public string Title { get; set; } = string.Empty;
    public EHarvestType HarvestType { get; set; } = EHarvestType.Programmed;
    public long ProductId { get; set; }
    public decimal QuantityInKg { get; set; }
    
    [Required (ErrorMessage = "Data inválida")]
    public DateTime? EndDate { get; set; }
    
}