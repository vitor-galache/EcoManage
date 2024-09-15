using EcoManage.Domain.Entities;
using Microsoft.AspNetCore.Components;

namespace EcoManage.Web.Components.Productions;

public partial class ProductionActionsComponent : ComponentBase
{
    #region Properties
    
    [Parameter,EditorRequired]
    public Production Production { get; set; } = null!;

    #endregion
}