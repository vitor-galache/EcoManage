using EcoManage.Domain.Entities;
using EcoManage.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcoManage.Api.Data.Mappings;

public class SupplierMapping : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.ToTable("Supplier");
        builder.HasKey(x => x.Id);
        
        builder.Property(x=>x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
        
        builder.Property(x => x.CompanyName)
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(255)
            .IsRequired();
        
        builder.Ignore(x => x.Notifications);
        
        builder.Property(x => x.Email)
            .HasColumnName("Email")
            .HasColumnType("VARCHAR")
            .HasMaxLength(255)
            .IsRequired()
            .HasConversion(
                v => v.ToString(), 
                v => new Email(v));

        builder.OwnsOne(x => x.Document, document =>
        {
            document.Ignore(x => x.Notifications);

            document.Property(n => n.Number)
                .HasColumnName("Document")
                .HasColumnType("VARCHAR")
                .HasMaxLength(14)
                .IsRequired();

            document.Property(x => x.Type)
                .HasColumnName("DocumentType")
                .IsRequired()
                .HasConversion<string>();
        });
        
        
        builder.OwnsOne(x => x.Address, address =>
        {
            address.Ignore(x => x.Notifications);
            address.Property(p => p.Street)
                .HasColumnName("Street")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(150)
                .IsRequired();

            address.Property(p => p.Number)
                .HasColumnName("Number")
                .HasColumnType("VARCHAR")
                .HasMaxLength(20)
                .IsRequired();
        });
    
        
        builder.OwnsOne(x => x.ZipCode, zipCode =>
        {
            zipCode.Ignore(x => x.Notifications);

            zipCode.Property(c => c.Code)
                .HasColumnName("ZipCode")
                .HasColumnType("VARCHAR")
                .HasMaxLength(8)
                .IsRequired();
        });
        
        
        builder.Property(x => x.Contact)
            .IsRequired(false)
            .HasColumnName("Contact")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(160);
    }
}