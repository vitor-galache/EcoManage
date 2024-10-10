using EcoManage.Domain;
using EcoManage.Domain.Handlers;
using EcoManage.Mobile.Handlers;
using EcoManage.Mobile.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Hosting;
using System.Net;
using System.Net.Http;

namespace EcoManage.Mobile
{
    public static class MauiProgram
    {
        public static string BackendUrl { get; set; } = "http://192.168.15.8:5017/";
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });


#if DEBUG
            builder.Logging.AddDebug();
#endif
            
            builder.Services.AddTransient<IAccountHandler, AccountHandler>();
            builder.Services.AddTransient<IProductHandler, ProductHandler>();
            return builder.Build();
        }

    }

}
