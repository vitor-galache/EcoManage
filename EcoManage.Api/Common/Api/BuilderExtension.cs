using EcoManage.Api.Data;
using EcoManage.Api.Handlers;
using EcoManage.Api.Models;
using EcoManage.Domain;
using EcoManage.Domain.Handlers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EcoManage.Api.Common.Api;

public static class BuilderExtension
{

    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        Configuration.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        Configuration.BackendUrl = builder.Configuration.GetValue<string>("BackendUrl")?? string.Empty;
        Configuration.FrontendUrl = builder.Configuration.GetValue<string>("FrontendUrl") ?? string.Empty;
    }
    public static void AddDbContexts(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(x => { x.UseSqlServer(Configuration.ConnectionString); });
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