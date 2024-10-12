using System.Runtime.InteropServices;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Supplier;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace EcoManage.Web.Pages.Suppliers;

public partial class CreateSupplierPage  : ComponentBase
{
    #region Properties

    public bool IsBusy { get; set; }
    public CreateSupplierRequest InputModel { get; set; } = new();
    
    #endregion

    #region Services

    [Inject] private ISupplierHandler Handler { get; set; } = null!;
    [Inject] public ISnackbar Snackbar { get; set; } = null!;
    [Inject] public NavigationManager NavigationManager { get; set; } = null!;

    #endregion

    #region Methods

    public async Task OnValidSubmitAsync()
    {
        IsBusy = true;
        try
        {
            var result = await Handler.CreateAsync(InputModel);
            
            if (result.IsSuccess)
            {
                Snackbar.Add(result.Message, Severity.Success);
                NavigationManager.NavigateTo("/fornecedores");
            }
            else
            {
                Snackbar.Add(result.Message, Severity.Error);
            }

        }
        catch (Exception ex)
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