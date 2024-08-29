using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Supplier;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace EcoManage.Web.Pages.Suppliers;

public partial class EditSupplierPage : ComponentBase
{
    [Parameter] public string Id { get; set; } = string.Empty;

    #region Properties

    public bool IsBusy { get; set; }
    public UpdateSupplierRequest InputModel { get; set; } = new();

    #endregion

    #region Services

    [Inject] private ISupplierHandler Handler { get; set; } = null!;
    [Inject] public ISnackbar Snackbar { get; set; } = null!;
    [Inject] public NavigationManager NavigationManager { get; set; } = null!;

    #endregion

    #region Overrides

    protected override async Task OnInitializedAsync()
    {
        GetSupplierByIdRequest? request = null;

        try
        {
            request = new GetSupplierByIdRequest()
            {
                Id = long.Parse(Id)
            };
        }
        catch (Exception)
        {
            Snackbar.Add("Parametro Inválido", Severity.Error);
        }

        if (request is null)
            return;

        IsBusy = true;

        try
        {
            var response = await Handler.GetByIdAsync(request);
            if (response is { IsSuccess: true, Data: not null })
                InputModel = new UpdateSupplierRequest
                {
                    Id = response.Data.Id,
                    CompanyName = response.Data.CompanyName,
                    Email = response.Data.Email.ToString(),
                    Contact = response.Data.Contact
                };

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
            var result = await Handler.UpdateAsync(InputModel);
            if (result.IsSuccess)
            {
                Snackbar.Add(result.Message, Severity.Success);
                NavigationManager.NavigateTo("/fornecedores");
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