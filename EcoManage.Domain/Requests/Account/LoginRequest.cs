using System.ComponentModel.DataAnnotations;

namespace EcoManage.Domain.Requests.Account;

public class LoginRequest : Request
{
    [Required (ErrorMessage = "E-mail obrigatório")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string Email { get; set; } = string.Empty;
    
    [Required (ErrorMessage = "Senha obrigatória")]
    public string Password { get; set; } = string.Empty;
}