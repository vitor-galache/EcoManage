using System.ComponentModel.DataAnnotations;

namespace EcoManage.Domain.Requests.Supplier;

public class UpdateSupplierRequest : Request
{
    public long Id { get; set; }
    
    [Required]
    public string CompanyName { get; set; } = string.Empty;
    
    [Required]
    public string Email { get; set; } = null!;
    
    public string? Contact { get; set; }
}
