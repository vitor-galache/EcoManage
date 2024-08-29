using System.ComponentModel.DataAnnotations;

namespace EcoManage.Domain.Requests.Supplier;

public class CreateSupplierRequest : Request
{
    [Required (ErrorMessage = "O nome comporativo é obrigatório")]
    public string CompanyName { get; set; } = string.Empty;
    
    [Required (ErrorMessage = "Documento obrigatório")]
    public string DocumentNumber { get; set; } = null!;
    
    [Required (ErrorMessage = "Digite a rua")]
    public string Street { get; set; } = null!;

    [Required (ErrorMessage = "Digite o número")] 
    public string Number { get; set; } = null!;

    [Required (ErrorMessage = "Digite o código postal")] 
    public string ZipCode { get; set; } = null!;
    
    [Required (ErrorMessage = "Digite o E-mail")]
    [EmailAddress (ErrorMessage = "E-mail inválido")]
    public string Email { get; set; } = null!;
    
    public string? Contact { get; set; }
}