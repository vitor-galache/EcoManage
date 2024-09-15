using EcoManage.Domain.Entities;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Product;
using EcoManage.Domain.Requests.Production;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace EcoManage.Web.Pages.Productions;

public partial class CreateProductionPage : ComponentBase
{
    #region Properties

    public bool IsBusy { get; set; }
    public List<Product> Products { get; set; } = [];

    public CreateProductionRequest InputModel { get; set; } = new();
    
    #endregion

    #region Services

    [Inject] public IProductionHandler ProductionHandler { get; set; } = null!;
    [Inject] public IProductHandler ProductHandler { get; set; } = null!;
    [Inject] public NavigationManager NavigationManager { get; set; } = null!;
    [Inject] public ISnackbar Snackbar { get; set; } = null!;

    #endregion

    #region Overrides

    protected override async Task OnInitializedAsync()
    {
        IsBusy = true;

        try
        {
            var request = new GetAllProductsRequest();
            var result = await ProductHandler.GetAllAsync(request);
            if (result.IsSuccess)
                Products = result.Data ?? [];
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

    #region Methods

    public async Task OnValidSubmitAsync()
    {
        IsBusy = true;

        try
        {
            var result = await ProductionHandler.CreateProductionAsync(InputModel);
         
            if (result.IsSuccess)
            {
                Snackbar.Add($"Produção {result.Data?.Number} cadastrada com sucesso!", Severity.Success);
                NavigationManager.NavigateTo("/producoes");
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