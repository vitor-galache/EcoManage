using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoManage.Mobile.Pages.Product;

public partial class CreateProductPage : ContentPage
{
    private readonly IProductHandler productHandler = null!;
    public CreateProductPage()
    {
        productHandler = IPlatformApplication.Current.Services.GetService<IProductHandler>();
        InitializeComponent();
    }

    private async void btn_SaveProduct_Clicked(object sender, EventArgs e)
    {
        var request = new CreateProductRequest { Title = InputTitle.Text, Description = InputDescription.Text };

        var result = await productHandler.CreateAsync(request);

        if (!result.IsSuccess)
        {
            await DisplayAlert("ERRO", result.Message, "OK");
            return;
        }
        else
        {
            await DisplayAlert("SUCESSO",result.Message, "OK");
            Navigation.RemovePage(this);
            await Navigation.PushAsync(new MainPage());
        }
    }
}