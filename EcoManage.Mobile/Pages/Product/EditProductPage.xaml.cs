using EcoManage.Domain.Handlers;
using ProductModel = EcoManage.Domain.Entities.Product;
using EcoManage.Domain.Requests.Product;
namespace EcoManage.Mobile.Pages.Product;

public partial class EditProductPage : ContentPage
{
    public readonly IProductHandler productHandler = null!;

    private readonly ProductModel _product;

    public EditProductPage(ProductModel product)
    {
        InitializeComponent();
        productHandler = IPlatformApplication.Current.Services.GetService<IProductHandler>();

        _product = product;

        InputTitle.Text = _product.Title;
        InputDescription.Text = _product.Description;
    }

    private async void btn_UpdateProduct_Clicked(object sender, EventArgs e)
    {
        var updateRequest = new UpdateProductRequest()
        {
            Id = _product.Id,
            Title = InputTitle.Text,
            Description = InputDescription.Text
        };
        var result = await productHandler.UpdateAsync(updateRequest);

        if (!result.IsSuccess)
        {
            await DisplayAlert("ERRO", result.Message, "OK");
            return;
        }
        else
        {
            await DisplayAlert("SUCESSO", result.Message, "OK");
            Navigation.RemovePage(this);
            await Navigation.PushAsync(new ProductsPage());
        }
        
    }

    private async void btn_InactiveProduct_Clicked(object sender, EventArgs e)
    {
        bool confirm = await DisplayAlert("Confirmação", "Você realmente deseja inativar este produto", "SIM", "NÃO");

        if (confirm) 
        {
            var inactiveRequest = new InactivateProductRequest() { Id = _product.Id };

            var result = await productHandler.InactiveAsync(inactiveRequest);

            if (!result.IsSuccess)
            {
                await DisplayAlert("ERRO", result.Message, "OK");
                return;
            }
            else
            {
                await DisplayAlert("SUCESSO", result.Message, "OK");
                Navigation.RemovePage(this);
                await Navigation.PushAsync(new ProductsPage());
            }
        }
    }
}