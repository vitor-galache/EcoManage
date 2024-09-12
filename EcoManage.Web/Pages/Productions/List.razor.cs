using EcoManage.Domain.Entities;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Production;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace EcoManage.Web.Pages.Productions;

public partial class ListProductionsPage : ComponentBase
{
    #region Properties

    public bool IsBusy { get; set; }

    public List<Production> Productions { get; set; } = [];

    #endregion

    #region Services

    [Inject] public ISnackbar Snackbar { get; set; } = null!;

    [Inject] public IProductionHandler Handler { get; set; } = null!;

    [Inject] public IDialogService DialogService { get; set; } = null!;

    #endregion

    #region Overrides

    protected override async Task OnInitializedAsync()
    {
        IsBusy = true;

        try
        {
            var request = new GetAllProductionsRequest();
            var result = await Handler.GetAllAsync(request);
            if (result.IsSuccess)
                Productions = result.Data ?? [];
        }
        catch(Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
        finally
        {
            IsBusy = false;
        }
    }

    #endregion
}