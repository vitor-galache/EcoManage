using EcoManage.Domain.Entities;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Production;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace EcoManage.Web.Pages.Productions;

public partial class DetailsProductionPage : ComponentBase
{
    #region Parameters
    
    [Parameter]
    public string Number { get; set; } = string.Empty;

    #endregion
    
    #region Properties
    
    public Production Production { get; set; } = null!;

    #endregion


    #region Services

    [Inject] public IProductionHandler Handler { get; set; } = null!;
    [Inject] public ISnackbar Snackbar { get; set; } = null!;
    [Inject] public NavigationManager NavigationManager { get; set; } = null!;
    #endregion

    #region Overrides

    protected override async Task OnInitializedAsync()
    {
        GetProductionByNumberRequest? request;
        request = new GetProductionByNumberRequest { Number = Number};

        var result = await Handler.GetByNumberAsync(request);
        if (result.IsSuccess)
        {
            Production = result.Data!;
        }
        else
        {
            Snackbar.Add(result.Message, Severity.Error);
        }
    }

    #endregion

    #region Public Methods

    public void RefreshState(Production production)
    {
        Production = production;
        StateHasChanged();
    }

    #endregion

}