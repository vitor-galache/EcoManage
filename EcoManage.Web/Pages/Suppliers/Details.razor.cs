using EcoManage.Domain.Entities;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Supplier;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace EcoManage.Web.Pages.Suppliers;

public partial class DetailsSupplierPage : ComponentBase
{
    #region Properties

    [Parameter] public string Id { get; set; } = string.Empty;
    public bool IsBusy { get; set; }

    public Supplier Supplier { get; set; } = null!;
    
    #endregion

    #region Services

    [Inject] private ISupplierHandler Handler { get; set; } = null!;
    [Inject] public ISnackbar Snackbar { get; set; } = null!;
    [Inject] public NavigationManager NavigationManager { get; set; } = null!;

    #endregion


    #region Overrides

    protected override async Task OnInitializedAsync()
    {
        GetSupplierByIdRequest? request  = null;
        try
        {
            request = new GetSupplierByIdRequest()
            {
                Id = long.Parse(Id)
            };
        }
        catch (Exception)
        {
            Snackbar.Add("Parametro inválido", Severity.Error);
        }

        if (request is null)
            return;
        
        var result = await Handler.GetByIdAsync(request);
        Supplier = result.Data!;

    }

    #endregion
}