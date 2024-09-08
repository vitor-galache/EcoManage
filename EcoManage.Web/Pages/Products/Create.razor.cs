using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Product;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace EcoManage.Web.Pages.Products;

public partial class CreateProductPage  : ComponentBase
{
    #region Properties

    public CreateProductRequest InputModel { get; set; } = new();
    public bool IsBusy { get; set; }
    
    #endregion

    #region Services
    
    [Inject]
    public IProductHandler Handler { get; set; } = null!;

    [Inject] 
    public ISnackbar Snackbar { get; set; } = null!;

    [Inject] 
    public NavigationManager NavigationManager { get; set; } = null!;

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
                NavigationManager.NavigateTo("/produtos");
            }
            else
                Snackbar.Add(result.Message, Severity.Error);

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