using System.ComponentModel.DataAnnotations;

namespace EcoManage.Domain.Requests.Production;

public class CreateProductionUnexpectedRequest : Request
{
    [Required (ErrorMessage = "Titulo obrigatório")]
    public string Title { get; set; } = string.Empty;
    
    [Required]
    public long ProductId { get; set; }
    
    [Required]
    public decimal QuantityInKg { get; set; }
}