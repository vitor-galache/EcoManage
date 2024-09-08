using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Product;
using EcoManage.Domain.Requests.Production;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace EcoManage.Web.Pages.Products;

public partial class EditProductPage : ComponentBase
{
    [Parameter] 
    public string Id { get; set; } = string.Empty;
    
    #region Properties

    public bool IsBusy { get; set; }

    public UpdateProductRequest InputModel { get; set; } = new();

    #endregion

    #region Services

    [Inject] private IProductHandler Handler { get; set; } = null!;
    [Inject] public ISnackbar Snackbar { get; set; } = null!;
    [Inject] public NavigationManager NavigationManager { get; set; } = null!;

    #endregion


    #region Overrides

    protected override async Task OnInitializedAsync()
    {
        GetProductByIdRequest? request = null;

        try
        {
            request = new GetProductByIdRequest()
            {
                Id = long.Parse(Id)
            };
        }
        catch
        {
            Snackbar.Add("Parametro inválido", Severity.Error);
        }

        if (request is null)
            return;

        IsBusy = true;

        try
        {
            var response = await Handler.GetByIdAsync(request);
            if (response is { IsSuccess: true, Data: not null })
                InputModel = new UpdateProductRequest
                {
                    Id = response.Data.Id,
                    Title = response.Data.Title,
                    Description = response.Data.Description,
                };
        }
        catch
        {
            Snackbar.Add("Não foi possível atualizar o produto", Severity.Error);
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
            var result = await Handler.UpdateAsync(InputModel);
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