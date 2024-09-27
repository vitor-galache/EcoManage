using MudBlazor;

namespace EcoManage.Web;

public static class Configuration
{
    
    public const string HttpClientName = "ecomanage";

    public static string BackendUrl { get; set; } = "";
    
    public static MudTheme Theme = new()
    {
        Typography = new Typography()
        {
            H3 = new ()
            {
                FontFamily = ["Lora","serif"]
            },
            
            H5 = new ()
            {
                FontFamily = ["Lora","serif"]
            },
            Default = new Default
            {
                FontFamily = ["Nunito", "sans-serif"]
            }
        },
        
        PaletteLight = new PaletteLight
        {
            Primary = "#659157",
            Secondary = Colors.LightGreen.Darken3,
            Background = "#FDF5E6",
            AppbarBackground = "#4F4F4F",
            AppbarText = Colors.Shades.White,
            TextPrimary = Colors.Shades.Black,
            PrimaryContrastText = Colors.Shades.Black,
            DrawerText = Colors.Shades.Black,
            DrawerBackground = Colors.LightGreen.Lighten4,
            Info = "#69A2B0"
        },
        PaletteDark = new PaletteDark
        {
            Primary = "#659157",
            Secondary = Colors.LightGreen.Darken3,
            Background = Colors.Gray.Darken4,
            AppbarBackground = Colors.Gray.Darken3,
            AppbarText = Colors.Shades.White,
            DrawerBackground = Colors.BlueGray.Darken2,
            DrawerText = Colors.Shades.White,
            Info = "#69A2B0"
        }
    };
}