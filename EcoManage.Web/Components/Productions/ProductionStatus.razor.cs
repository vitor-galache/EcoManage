using EcoManage.Domain.Enums;
using Microsoft.AspNetCore.Components;

namespace EcoManage.Web.Components.Productions;

public partial class ProductionStatusComponent : ComponentBase
{
    [Parameter,EditorRequired] public EProductionStatus Status { get; set; }
}