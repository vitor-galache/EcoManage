using EcoManage.Api;
using EcoManage.Api.Common.Api;
using EcoManage.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);



builder.AddConfiguration();
builder.AddSecurity();
builder.AddDbContexts();
builder.AddCrossOrigin();
builder.AddDocumentation();
builder.AddServices();

var app = builder.Build();



if (app.Environment.IsDevelopment())
    app.ConfigureDevEnviroment();

app.UseCors(ApiConfiguration.CorsPolicyName);
app.UseAuthentication();
app.UseAuthorization();
app.UseSecurity();

app.ApllyMigrations();

app.MapEndpoints();

app.Run();