using System.ComponentModel.DataAnnotations;

namespace EcoManage.Domain.Requests.Supplier;

public class CreateSupplierRequest : Request
{
    [Required]
    public string CompanyName { get; set; } = string.Empty;
    
    [Required (ErrorMessage = "Documento Inválido")]
    public string DocumentNumber { get; set; } = null!;
    
    [Required]
    public string Street { get; set; } = null!;

    [Required] 
    public string Number { get; set; } = null!;

    [Required] 
    public string ZipCode { get; set; } = null!;
    
    [Required]
    public string Email { get; set; } = null!;
    
    public string? Contact { get; set; }
}