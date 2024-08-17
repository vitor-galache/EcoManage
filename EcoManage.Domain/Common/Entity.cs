using Flunt.Notifications;

namespace EcoManage.Domain.Common;

public abstract class Entity : Notifiable
{
    public string Id { get; set; } = Guid.NewGuid().ToString().Replace("-","").Substring(0,12);
}