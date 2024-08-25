namespace EcoManage.Api.Common.Api;

public static class AppExtension
{
    public static void ConfigureDevEnviroment(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.MapSwagger().RequireAuthorization();
    } 

    public static void UseSecurity(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }
}