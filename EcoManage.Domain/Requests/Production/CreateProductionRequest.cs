using System.ComponentModel.DataAnnotations;
using EcoManage.Domain.Enums;

namespace EcoManage.Domain.Requests.Production;

public class CreateProductionRequest : Request
{
    [Required (ErrorMessage = "Titulo obrigatório")]
    public string Title { get; set; } = string.Empty;
    
    [Required (ErrorMessage = "Produto inválido")]
    public long ProductId { get; set; }

    [Required(ErrorMessage = "Tipo de colheita inválido")]
    public EHarvestType HarvestType { get; set; } = EHarvestType.Programmed;
    
    [Required (ErrorMessage = "Digite um número")]
    public decimal QuantityInKg { get; set; }
    
    [Required (ErrorMessage = "Insira a data prevista para conclusão")]
    public DateTime? EndDate { get; set; } 
}