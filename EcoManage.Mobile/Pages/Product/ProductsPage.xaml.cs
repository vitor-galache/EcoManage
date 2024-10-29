using EcoManage.Domain.Handlers;
using ProductModel = EcoManage.Domain.Entities.Product;
using EcoManage.Domain.Requests.Product;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace EcoManage.Mobile.Pages.Product;

public partial class ProductsPage : ContentPage
{
    private readonly IProductHandler _productHandler = null!;
    public ObservableCollection<ProductModel> Products { get; set; } = new ObservableCollection<ProductModel>();
    public ICommand NavigateToEditCommand { get; }

    public ProductsPage()
    {
        InitializeComponent();
        BindingContext = this;
        NavigateToEditCommand = new Command<ProductModel>(NavigateToEditPage);
        _productHandler = IPlatformApplication.Current.Services.GetService<IProductHandler>();
        CarregarProdutos();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        CarregarProdutos();
    }
    private async void NavigateToEditPage(ProductModel product)
    {
        await Application.Current.MainPage.Navigation.PushAsync(new EditProductPage(product));
    }
    private async void CarregarProdutos()
    {
        var request = new GetAllProductsRequest();
        var result = await _productHandler.GetAllAsync(request);
        if (result.Data == null)
        {
            await DisplayAlert("Não há produtos", result.Message, "OK");
        }

        ProdutosCollectionView.ItemsSource = result.Data;
    }
}