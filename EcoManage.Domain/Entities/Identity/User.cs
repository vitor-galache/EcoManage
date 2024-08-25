namespace EcoManage.Domain.Entities.Identity;

public class User
{
    public string Email { get; set; } = string.Empty;

    public bool IsEmailConfirmed { get; set; }

    public Dictionary<string, string> Claims { get; set; } = [];
}