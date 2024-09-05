using System.ComponentModel.DataAnnotations;

namespace EcoManage.Domain.Requests.Product;

public class CreateProductRequest
{  
    [Required (ErrorMessage = "Título obrigatório")]
    public string Title { get; set; } = string.Empty;
    
    [Required (ErrorMessage = "Descrição obrigatória")]
    public string Description { get; set; } = string.Empty;
}