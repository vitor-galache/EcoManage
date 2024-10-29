using Microsoft.AspNetCore.Identity;

namespace EcoManage.Persistence.Models;

public class User : IdentityUser<long>
{
    public List<IdentityRole<long>>? Roles { get; set; }
}