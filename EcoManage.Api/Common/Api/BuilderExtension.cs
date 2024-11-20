using EcoManage.Api.Handlers;
using EcoManage.Domain;
using EcoManage.Domain.Handlers;
using EcoManage.Persistence.Data;
using EcoManage.Persistence.Models;
using Microsoft.AspNetCore.Identity;

namespace EcoManage.Api.Common.Api;

public static class BuilderExtension
{

    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        if (builder.Environment.IsDevelopment())
        {
            builder.Configuration.AddUserSecrets<Program>();
        }
        Configuration.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        Configuration.BackendUrl = builder.Configuration.GetValue<string>("BackendUrl")?? string.Empty;
        Configuration.FrontendUrl = builder.Configuration.GetValue<string>("FrontendUrl") ?? string.Empty;
    }
    public static void AddDbContexts(this WebApplicationBuilder builder)
    {
        Persistence.Dependencies.ConfigureDataServices(builder.Configuration,builder.Services);
        builder.Services.AddIdentityCore<User>()
            .AddRoles<IdentityRole<long>>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddApiEndpoints();
    }

    public static void AddSecurity(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddAuthentication(IdentityConstants.ApplicationScheme)
            .AddIdentityCookies();
        
        builder.Services.AddAuthorization();
    }
    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<ISupplierHandler, SupplierHandler>();
        builder.Services.AddTransient<IProductHandler,ProductHandler>();
        builder.Services.AddTransient<IProductionHandler, ProductionHandler>();
        builder.Services.AddTransient<IReportHandler, ReportHandler>();
    } 
    
    public static void AddDocumentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(x=>{x.CustomSchemaIds(n=>n.FullName);});
    }

    public static void AddCrossOrigin(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(
                ApiConfiguration.CorsPolicyName,
                policy =>
                    policy.WithOrigins([Configuration.BackendUrl,Configuration.FrontendUrl])
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
            );
        });
    }
}