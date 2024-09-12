using System.Text.Json;
using System.Text.Json.Serialization;
using EcoManage.Domain.Common;
using EcoManage.Domain.Handlers;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using EcoManage.Web;
using EcoManage.Web.Handlers;
using EcoManage.Web.Security;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
Configuration.BackendUrl = builder.Configuration.GetValue<string>("BackendUrl") ?? string.Empty;
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped<CookieHandler>();
builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<AuthenticationStateProvider,CookieAuthenticationStateProvider>();
builder.Services.AddScoped(x => (ICookieAuthenticationStateProvider)x.GetRequiredService<AuthenticationStateProvider>());


builder.Services.AddTransient<IAccountHandler, AccountHandler>();
builder.Services.AddTransient<ISupplierHandler, SupplierHandler>();
builder.Services.AddTransient<IProductHandler, ProductHandler>();
builder.Services.AddTransient<IProductionHandler, ProductionHandler>();

builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.SnackbarVariant = Variant.Outlined;
});

builder.Services.AddHttpClient(Configuration.HttpClientName, opt =>
{
    
    opt.BaseAddress = new Uri(Configuration.BackendUrl);
}).AddHttpMessageHandler<CookieHandler>();


await builder.Build().RunAsync();
