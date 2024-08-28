using EcoManage.Domain.Entities;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Supplier;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace EcoManage.Web.Pages.Suppliers;

public partial class ListSupplierPage : ComponentBase
{
    #region Properties

    public bool IsBusy { get; set; }

    public List<Supplier> Suppliers { get; set; } = [];

    #endregion

    #region Services

    [Inject] public ISnackbar Snackbar { get; set; } = null!;

    [Inject] public ISupplierHandler Handler { get; set; } = null!;

    #endregion

    #region Overrides

    protected override async Task OnInitializedAsync()
    {
        IsBusy = true;

        try
        {
            var request = new GetAllSupplierRequest();
            var result = await Handler.GetAllAsync(request);
            if (result.IsSuccess)
                Suppliers = result.Data ?? [];
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
        finally
        {
            IsBusy = true;
        }
    }

    #endregion

    #region Methods

    #endregion
}