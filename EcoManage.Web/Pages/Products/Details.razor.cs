using EcoManage.Domain.Entities;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Product;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace EcoManage.Web.Pages.Products;

public partial class DetailsProductPage : ComponentBase
{

    #region Parameters

    [Parameter]
    public string Slug { get; set; } = string.Empty;

    #endregion
    
    
    #region Properties
    public Product Product { get; set; } = null!;

    #endregion

    #region Services

    [Inject] public IProductHandler Handler { get; set; } = null!;
    [Inject] public ISnackbar Snackbar { get; set; } = null!;
    [Inject] public NavigationManager NavigationManager { get; set; } = null!;

    #endregion


    #region Overrides

    protected override async Task OnInitializedAsync()
    {
        GetProductBySlugRequest? request;
        request = new GetProductBySlugRequest()
        {
            Slug = Slug
        };

        
        var result = await Handler.GetBySlugAsync(request);
        if (result.IsSuccess)
        {
            Product = result.Data!;
        }
        else
        {
            Snackbar.Add(result.Message, Severity.Error);
        }
    }

    #endregion
}