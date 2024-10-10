using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Product;

namespace EcoManage.Mobile.Pages.Product;

public partial class ProductsPage : ContentPage
{
    private readonly IProductHandler _productHandler = null!;
    public ProductsPage()
    {
        InitializeComponent();
        _productHandler = IPlatformApplication.Current.Services.GetService<IProductHandler>();
        CarregarProdutos();
    }

    private async void CarregarProdutos()
    {
        var request = new GetAllProductsRequest();
        var result = await _productHandler.GetAllAsync(request);
        if (result.Data == null)
        {
            await DisplayAlert("ERRO", result.Message, "OK");
        }

        ProdutosCollectionView.ItemsSource = result.Data;
    }
}