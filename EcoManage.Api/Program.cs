using EcoManage.Api;
using EcoManage.Api.Common.Api;
using EcoManage.Api.Endpoints;


var builder = WebApplication.CreateBuilder(args);

builder.AddConfiguration();
builder.AddDbContexts();
builder.AddCrossOrigin();
builder.AddServices();

builder.AddDocumentation();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.ConfigureDevEnviroment();

app.UseCors(ApiConfiguration.CorsPolicyName);

app.MapEndpoints();

app.Run();