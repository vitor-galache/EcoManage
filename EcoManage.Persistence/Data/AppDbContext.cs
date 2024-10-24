using System.Reflection;
using EcoManage.Domain.Entities;
using EcoManage.Domain.Entities.Productions;
using EcoManage.Domain.Entities.Reports;
using EcoManage.Persistence.Models;
using Flunt.Notifications;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EcoManage.Persistence.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options)
    : IdentityDbContext<
            User,
            IdentityRole<long>,
            long,
            IdentityUserClaim<long>,
            IdentityUserRole<long>,
            IdentityUserLogin<long>,
            IdentityRoleClaim<long>,
            IdentityUserToken<long>
        >(options)
{
    public DbSet<Supplier> Suppliers { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Production> Productions { get; set; } = null!;
    public DbSet<ProductionsByPeriod> ProductionsByPeriod { get; set; } = null!;

    public DbSet<TotalProducts> TotalProducts { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<Notification>();
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<ProductionsByPeriod>()
            .HasNoKey()
            .ToView("vwGetProductionsByPeriod");
        
        modelBuilder.Entity<TotalProducts>()
            .HasNoKey()
            .ToView("vwGetTotalProducts");
    }
}