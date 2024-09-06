using System.ComponentModel.DataAnnotations;
using EcoManage.Domain.Enums;

namespace EcoManage.Domain.Requests.Production;

public class CreateProductionProgrammedRequest : Request
{
    [Required (ErrorMessage = "Titulo obrigatório")]
    public string Title { get; set; } = string.Empty;
    
    [Required]
    public long ProductId { get; set; }
    
    [Required]
    public decimal QuantityInKg { get; set; }
    
    [Required (ErrorMessage = "Data inválida")]
    public DateTime EndDate { get; set; }
    
}