using EcoManage.Domain.Handlers;
using EcoManage.Web.Security;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace EcoManage.Web.Pages.Identity;

public partial class LogoutPage : ComponentBase
{
    #region Services
    
    [Inject]
    private IAccountHandler Handler { get; set; } = null!;
    [Inject]
    private ISnackbar Snackbar { get; set; } = null!;
    [Inject] 
    private NavigationManager NavigationManager { get; set; } = null!;
    [Inject] 
    private ICookieAuthenticationStateProvider AuthenticationStateProvider { get; set; } = null!;
    
    #endregion

    #region Overrides

    protected override async Task OnInitializedAsync()
    {
        if (await AuthenticationStateProvider.CheckAuthenticatedAsync())
        {
            await Handler.LogoutAsync();
            await AuthenticationStateProvider.GetAuthenticationStateAsync();
            AuthenticationStateProvider.NotifyAuthenticationStateChanged();
        }

        await base.OnInitializedAsync();
    }

    #endregion
}