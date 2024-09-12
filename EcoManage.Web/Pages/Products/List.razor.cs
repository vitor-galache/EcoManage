using EcoManage.Domain.Entities;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Product;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace EcoManage.Web.Pages.Products;

public partial class ListProductsPage : ComponentBase
{
    #region Properties
    
    public bool IsBusy { get; set; }

    public List<Product> Products { get; set; } = [];

    #endregion

    #region Services

    [Inject] public ISnackbar Snackbar { get; set; } = null!;

    [Inject] public IDialogService DialogService { get; set; } = null!;
    [Inject] public IProductHandler Handler { get; set; } = null!;
    
    #endregion


    #region Overrides

    protected override async Task OnInitializedAsync()
    {
        IsBusy = true;
        try
        {
            var request = new GetAllProductsRequest();
            var result = await Handler.GetAllAsync(request);
            if (result.IsSuccess)
                Products = result.Data ?? [];

        }
        catch
        {
            Snackbar.Add("Não foi possível carregar produtos", Severity.Error);
        }
        finally
        {
            IsBusy = false;
        }
    }

    #endregion


    #region Methods
    
    public async Task OnInactivateButtonAsync(long id, string productName)
    {
        
        var result = await DialogService.ShowMessageBox( "ATENÇÃO",
            $"Ao prosseguir o produto {productName} será inativado e não estará mais disponível no sistema. Deseja continuar?",
            yesText: "INATIVAR PRODUTO",
            cancelText: "Cancelar");
        
        if (result is true)
            await OnInactivateAsync(id, productName);
        
        StateHasChanged();
    }
    
    public async Task OnInactivateAsync(long id, string productName)
    {
        try
        {
            var request = new InactivateProductRequest() { Id = id };
            await Handler.InactiveAsync(request);
            Products.RemoveAll(x => x.Id == id);
            Snackbar.Add($"Produto {productName} inativado com sucesso", Severity.Info);
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }

    #endregion
    
}