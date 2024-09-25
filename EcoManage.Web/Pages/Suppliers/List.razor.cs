using EcoManage.Domain.Entities;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Supplier;
using EcoManage.Domain.Responses;
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
    [Inject] public IDialogService DialogService { get; set; } = null!;
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
        catch
        {
            Snackbar.Add("Não foi possível carregar fornecedores", Severity.Error);
        }
        finally
        {
            IsBusy = false;
        }
    }

    #endregion

    #region Methods
    public async Task OnDeleteButtonAsync(long id, string companyName)
    {
        
        var result = await DialogService.ShowMessageBox( "ATENÇÃO",
            $"Ao prosseguir o fornecedor {companyName} será excluído. Esta é uma ação irreversível! Deseja continuar?",
            yesText: "EXCLUIR FORNECEDOR",
            cancelText: "Cancelar");
        
        if (result is true)
            await OnDeleteAsync(id, companyName);
        
        StateHasChanged();
    }
    
    public async Task OnDeleteAsync(long id, string companyName)
    {
        try
        {
            var request = new DeleteSupplierRequest() { Id = id };
            await Handler.DeleteAsync(request);
            Suppliers.RemoveAll(x => x.Id == id);
            Snackbar.Add($"Fornecedor {companyName} excluído com sucesso", Severity.Info);
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }
    #endregion
}