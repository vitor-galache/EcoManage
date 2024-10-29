using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Account;

namespace EcoManage.Mobile.Pages;

public partial class LoginPage : ContentPage
{
    private readonly IAccountHandler _accountHandler;
    public LoginPage()
    {
        _accountHandler = IPlatformApplication.Current.Services.GetService<IAccountHandler>();
        InitializeComponent();
    }

    private async void btn_Login_Clicked(object sender, EventArgs e)
    {
        var email = InputEmail.Text;
        var password = InputPassword.Text;

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Erro", "Por favor,preencha todos os campos", "OK");
            return;
        }

        var request = new LoginRequest { Email = email, Password = password };

        var result = await _accountHandler.LoginAsync(request);

        if (!result.IsSuccess)
        {
            await DisplayAlert("ERRO", result.Message, "OK");
            return;
        }

        await Navigation.PushAsync(new MainPage());
    }
}