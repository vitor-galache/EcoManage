using EcoManage.Domain.Common;
using EcoManage.Domain.ValueObjects;

namespace EcoManage.Domain.Entities;

public class Supplier : Entity
{
    public string Name { get; set; } = string.Empty;
    public Document Document { get; set; } = null!;
    public Address Address { get; set; } = null!;
    public Email Email { get; set; } = null!;
    public string Contact { get; set; } = string.Empty;
}