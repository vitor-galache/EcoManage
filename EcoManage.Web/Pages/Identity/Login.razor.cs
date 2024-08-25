using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Account;
using EcoManage.Web.Security;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace EcoManage.Web.Pages.Identity;

public partial class LoginPage : ComponentBase
{
    #region Dependencies

    [Inject]
    public IAccountHandler Handler { get; set; } = null!;
    
    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;
    
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;
    
    [Inject]
    public ICookieAuthenticationStateProvider AuthenticationStateProvider { get; set; } = null!;
    #endregion

    #region Properties

    public LoginRequest InputModel { get; set; } = new();
    public bool IsBusy { get; private set; } = false;

    #endregion

    #region Overrides

    protected override async Task OnInitializedAsync()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;
        if (user.Identity is { IsAuthenticated:true})
            NavigationManager.NavigateTo("/");
    }

    #endregion

    #region Methods

    public async Task OnValidSubmitAsync()
    {
        IsBusy = true;
        try
        {
            var result = await Handler.LoginAsync(InputModel);

            if (result.IsSuccess)
            {
                await AuthenticationStateProvider.GetAuthenticationStateAsync();
                AuthenticationStateProvider.NotifyAuthenticationStateChanged();
                NavigationManager.NavigateTo("/");
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