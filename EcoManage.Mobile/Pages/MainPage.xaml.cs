using EcoManage.Mobile.Pages.Product;

namespace EcoManage.Mobile.Pages
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductsPage());
        }

        private async void BtnAddProduct_Clicked(object sender, EventArgs e)
        {
             await Navigation.PushAsync(new CreateProductPage());
        }
    }

}
