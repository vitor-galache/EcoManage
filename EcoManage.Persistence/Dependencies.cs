using EcoManage.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EcoManage.Persistence;

public static class Dependencies
{
    public static void ConfigureDataServices(IConfiguration configuration, IServiceCollection services)
    {
        bool useInMemoryDatabase = false;
        if (configuration["UseInMemoryDatabase"] != null)
        {
            useInMemoryDatabase = bool.Parse(configuration["UseInMemoryDatabase"]!);
        }

        if (useInMemoryDatabase)
            services.AddDbContext<AppDbContext>(opt=>opt.UseInMemoryDatabase("AppDbContext"));
        
        services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }
}