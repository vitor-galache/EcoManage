﻿// <auto-generated />
using System;
using EcoManage.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EcoManage.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EcoManage.Domain.Entities.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR");

                    b.Property<bool>("IsActive")
                        .HasColumnType("BIT");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Slug" }, "IX_Product_Slug")
                        .IsUnique();

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("EcoManage.Domain.Entities.Productions.Production", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("DATETIME2");

                    b.Property<string>("HarvestType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("CHAR");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("QuantityInKg")
                        .HasColumnType("DECIMAL(18,2)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("DATETIME2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex(new[] { "Number" }, "IX_Production_Number")
                        .IsUnique();

                    b.ToTable("Production", (string)null);

                    b.HasDiscriminator<string>("HarvestType");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("EcoManage.Domain.Entities.Reports.ProductionsByPeriod", b =>
                {
                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<int>("TotalProductions")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.ToTable((string)null);

                    b.ToView("vwGetProductionsByPeriod", (string)null);
                });

            modelBuilder.Entity("EcoManage.Domain.Entities.Reports.TotalProducts", b =>
                {
                    b.Property<string>("Product")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalProduced")
                        .HasColumnType("decimal(18,2)");

                    b.ToTable((string)null);

                    b.ToView("vwGetTotalProducts", (string)null);
                });

            modelBuilder.Entity("EcoManage.Domain.Entities.Supplier", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Name");

                    b.Property<string>("Contact")
                        .HasMaxLength(160)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Contact");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Email");

                    b.HasKey("Id");

                    b.ToTable("Supplier", (string)null);
                });

            modelBuilder.Entity("EcoManage.Persistence.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(180)
                        .HasColumnType("nvarchar(180)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(180)
                        .HasColumnType("nvarchar(180)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(180)
                        .HasColumnType("nvarchar(180)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(180)
                        .HasColumnType("nvarchar(180)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .IsUnique()
                        .HasFilter("[NormalizedEmail] IS NOT NULL");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("IdentityUser", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<long>", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.HasIndex("UserId");

                    b.ToTable("IdentityRole", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ClaimValue")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("IdentityRoleClaim", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ClaimValue")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("IdentityClaim", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("IdentityUserLogin", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("IdentityUserRole", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("Name")
                        .HasMaxLength(180)
                        .HasColumnType("nvarchar(180)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("IdentityUserToken", (string)null);
                });

            modelBuilder.Entity("EcoManage.Domain.Entities.Productions.ProductionProgrammed", b =>
                {
                    b.HasBaseType("EcoManage.Domain.Entities.Productions.Production");

                    b.HasDiscriminator().HasValue("Programmed");
                });

            modelBuilder.Entity("EcoManage.Domain.Entities.Productions.ProductionUnexpected", b =>
                {
                    b.HasBaseType("EcoManage.Domain.Entities.Productions.Production");

                    b.HasDiscriminator().HasValue("Unexpected");
                });

            modelBuilder.Entity("EcoManage.Domain.Entities.Productions.Production", b =>
                {
                    b.HasOne("EcoManage.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EcoManage.Domain.Entities.Supplier", b =>
                {
                    b.OwnsOne("EcoManage.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<long>("SupplierId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("VARCHAR")
                                .HasColumnName("Number");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(150)
                                .HasColumnType("NVARCHAR")
                                .HasColumnName("Street");

                            b1.HasKey("SupplierId");

                            b1.ToTable("Supplier");

                            b1.WithOwner()
                                .HasForeignKey("SupplierId");
                        });

                    b.OwnsOne("EcoManage.Domain.ValueObjects.Document", "Document", b1 =>
                        {
                            b1.Property<long>("SupplierId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasMaxLength(14)
                                .HasColumnType("VARCHAR")
                                .HasColumnName("Document");

                            b1.Property<string>("Type")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("DocumentType");

                            b1.HasKey("SupplierId");

                            b1.ToTable("Supplier");

                            b1.WithOwner()
                                .HasForeignKey("SupplierId");
                        });

                    b.OwnsOne("EcoManage.Domain.ValueObjects.ZipCode", "ZipCode", b1 =>
                        {
                            b1.Property<long>("SupplierId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Code")
                                .IsRequired()
                                .HasMaxLength(8)
                                .HasColumnType("VARCHAR")
                                .HasColumnName("ZipCode");

                            b1.HasKey("SupplierId");

                            b1.ToTable("Supplier");

                            b1.WithOwner()
                                .HasForeignKey("SupplierId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Document")
                        .IsRequired();

                    b.Navigation("ZipCode")
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<long>", b =>
                {
                    b.HasOne("EcoManage.Persistence.Models.User", null)
                        .WithMany("Roles")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.HasOne("EcoManage.Persistence.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.HasOne("EcoManage.Persistence.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.HasOne("EcoManage.Persistence.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.HasOne("EcoManage.Persistence.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EcoManage.Persistence.Models.User", b =>
                {
                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
