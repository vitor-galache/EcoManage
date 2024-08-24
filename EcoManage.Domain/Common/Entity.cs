using Flunt.Notifications;

namespace EcoManage.Domain.Common;

public abstract class Entity : Notifiable
{
    public long Id { get; init; } 
}