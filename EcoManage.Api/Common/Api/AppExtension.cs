using EcoManage.Persistence.Data;

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
    
    public static void ApllyMigrations(this IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            var serviceDb = serviceScope.ServiceProvider.GetService<AppDbContext>();
            
            serviceDb!.Database.EnsureCreated();
        }
    }
}
