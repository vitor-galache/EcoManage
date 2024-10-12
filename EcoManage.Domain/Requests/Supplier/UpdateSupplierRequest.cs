using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EcoManage.Domain.Requests.Supplier;

public class UpdateSupplierRequest : Request
{
    [JsonIgnore]
    public long Id { get; set; }
    
    [Required]
    public string CompanyName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
    public string? Contact { get; set; }
}
