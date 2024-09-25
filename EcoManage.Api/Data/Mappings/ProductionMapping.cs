using EcoManage.Domain.Entities.Productions;
using EcoManage.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcoManage.Api.Data.Mappings;

public class ProductionMapping : IEntityTypeConfiguration<Production>
{
    public void Configure(EntityTypeBuilder<Production> builder)
    {
        builder.ToTable("Production");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();

        builder.Property(x => x.Number)
            .IsRequired()
            .HasColumnType("CHAR")
            .HasMaxLength(8);
        
        
        builder.Property(x => x.Title)
            .IsRequired()
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.Status)
            .IsRequired()
            .HasConversion<string>();

        builder.Property(x => x.HarvestType)
            .IsRequired()
            .HasConversion<string>();

        builder.Property(x => x.StartDate)
            .IsRequired()
            .HasColumnType("DATETIME2");
        
        
        builder.Property(x => x.EndDate)
            .IsRequired(false)
            .HasColumnType("DATETIME2");

        builder.Property(x => x.QuantityInKg)
            .IsRequired()
            .HasColumnType("DECIMAL(18,2)");

        builder.HasOne(x => x.Product)
            .WithMany();

        builder.HasIndex(x => x.Number,"IX_Production_Number")
            .IsUnique();

        builder.HasDiscriminator<EHarvestType>("HarvestType")
            .HasValue<ProductionProgrammed>(EHarvestType.Programmed)
            .HasValue<ProductionUnexpected>(EHarvestType.Unexpected);
    }
}