﻿// <auto-generated />
using System;
using Delta.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Delta.Data.Migrations
{
    [DbContext(typeof(DeltaDbContext))]
    [Migration("20230911115355_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Delta.Data.AboutU", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AboutUs");
                });

            modelBuilder.Entity("Delta.Data.Certificate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.Property<string>("Pdf")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.HasKey("Id")
                        .HasName("Certificates_pkey");

                    b.ToTable("Certificates");
                });

            modelBuilder.Entity("Delta.Data.ClientApplication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AdditionalInfo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SitePage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UtmInfo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ClientApplications");
                });

            modelBuilder.Entity("Delta.Data.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id")
                        .HasName("Companies_pkey");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Delta.Data.Consumable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)");

                    b.HasKey("Id")
                        .HasName("Consumables_pkey");

                    b.ToTable("Consumables");
                });

            modelBuilder.Entity("Delta.Data.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("''::text");

                    b.Property<string>("Friday")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HeaderNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HeaderTimetable")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImgBg")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("''::text");

                    b.Property<string>("Monday")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NumberOne")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NumberTwo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Saturday")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Delta.Data.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CardTitle")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LongNamePrefix")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)");

                    b.Property<string>("ModelSeries")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<int>("ProductCategoriesId")
                        .HasColumnType("integer");

                    b.Property<string>("TechInfo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<short>("Type")
                        .HasColumnType("smallint");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id")
                        .HasName("Products_pkey");

                    b.HasIndex(new[] { "CompanyId" }, "IX_Products_CompanyId");

                    b.HasIndex(new[] { "ProductCategoriesId" }, "IX_Products_ProductCategoriesId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Delta.Data.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id")
                        .HasName("ProductCategories_pkey");

                    b.HasIndex(new[] { "ParentCategoryId" }, "IX_ProductCategories_ParentCategoryId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("Delta.Data.ProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsMain")
                        .HasColumnType("boolean");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.HasKey("Id")
                        .HasName("ProductImages_pkey");

                    b.HasIndex(new[] { "ProductId" }, "IX_ProductImages_ProductId");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("Delta.Data.Reagent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("integer");

                    b.Property<string>("InstructionPdf")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("''::text");

                    b.Property<string>("KitComposition")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id")
                        .HasName("Reagents_pkey");

                    b.HasIndex(new[] { "CompanyId" }, "IX_Reagents_CompanyId");

                    b.ToTable("Reagents");
                });

            modelBuilder.Entity("Delta.Data.ReagentCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id")
                        .HasName("ReagentCategories_pkey");

                    b.ToTable("ReagentCategories");
                });

            modelBuilder.Entity("Delta.Data.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AdditionalInfo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("'-infinity'::timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Rate")
                        .HasColumnType("integer");

                    b.Property<string>("SitePage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UtmInfo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Delta.Data.User", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserName", "Role");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProductCertificate", b =>
                {
                    b.Property<int>("CertificateId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.HasKey("CertificateId", "ProductId")
                        .HasName("ProductCertificatesPKey");

                    b.HasIndex(new[] { "ProductId" }, "IX_ProductCertificate_ProductId");

                    b.ToTable("ProductCertificate", (string)null);
                });

            modelBuilder.Entity("ProductConsumable", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("ConsumableId")
                        .HasColumnType("integer");

                    b.HasKey("ProductId", "ConsumableId")
                        .HasName("ProductConsumablesPKey");

                    b.HasIndex(new[] { "ConsumableId" }, "IX_ProductConsumable_ConsumableId");

                    b.ToTable("ProductConsumable", (string)null);
                });

            modelBuilder.Entity("ProductReagent", b =>
                {
                    b.Property<int>("ReagentId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.HasKey("ReagentId", "ProductId")
                        .HasName("ProductReagentsPKey");

                    b.HasIndex(new[] { "ProductId" }, "IX_ProductReagent_ProductId");

                    b.ToTable("ProductReagent", (string)null);
                });

            modelBuilder.Entity("ReagentCategoryReagent", b =>
                {
                    b.Property<int>("ReagentCategoryId")
                        .HasColumnType("integer");

                    b.Property<int>("ReagentId")
                        .HasColumnType("integer");

                    b.HasKey("ReagentCategoryId", "ReagentId")
                        .HasName("ReagentCategoryReagentsPKey");

                    b.HasIndex(new[] { "ReagentId" }, "IX_ReagentCategoryReagent_ReagentId");

                    b.ToTable("ReagentCategoryReagent", (string)null);
                });

            modelBuilder.Entity("Delta.Data.Product", b =>
                {
                    b.HasOne("Delta.Data.Company", "Company")
                        .WithMany("Products")
                        .HasForeignKey("CompanyId")
                        .IsRequired()
                        .HasConstraintName("CompanyId");

                    b.HasOne("Delta.Data.ProductCategory", "ProductCategories")
                        .WithMany("Products")
                        .HasForeignKey("ProductCategoriesId")
                        .IsRequired()
                        .HasConstraintName("ProductCategoriesId");

                    b.Navigation("Company");

                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("Delta.Data.ProductCategory", b =>
                {
                    b.HasOne("Delta.Data.ProductCategory", "ParentCategory")
                        .WithMany("InverseParentCategory")
                        .HasForeignKey("ParentCategoryId")
                        .HasConstraintName("ParentCategoryId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("Delta.Data.ProductImage", b =>
                {
                    b.HasOne("Delta.Data.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("ProductImages_ProductId_fkey");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Delta.Data.Reagent", b =>
                {
                    b.HasOne("Delta.Data.Company", "Company")
                        .WithMany("Reagents")
                        .HasForeignKey("CompanyId")
                        .IsRequired()
                        .HasConstraintName("Reagents_CompanyId_fkey");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("ProductCertificate", b =>
                {
                    b.HasOne("Delta.Data.Certificate", null)
                        .WithMany()
                        .HasForeignKey("CertificateId")
                        .IsRequired()
                        .HasConstraintName("ProductCertificates_CertificateId_fkey");

                    b.HasOne("Delta.Data.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("ProductCertificates_ProductId_fkey");
                });

            modelBuilder.Entity("ProductConsumable", b =>
                {
                    b.HasOne("Delta.Data.Consumable", null)
                        .WithMany()
                        .HasForeignKey("ConsumableId")
                        .IsRequired()
                        .HasConstraintName("ProductConsumables_ConsumableId_fkey");

                    b.HasOne("Delta.Data.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("ProductConsumables_ProductId_fkey");
                });

            modelBuilder.Entity("ProductReagent", b =>
                {
                    b.HasOne("Delta.Data.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("ProductReagents_ProductId_fkey");

                    b.HasOne("Delta.Data.Reagent", null)
                        .WithMany()
                        .HasForeignKey("ReagentId")
                        .IsRequired()
                        .HasConstraintName("ProductReagents_ReagentId_fkey");
                });

            modelBuilder.Entity("ReagentCategoryReagent", b =>
                {
                    b.HasOne("Delta.Data.ReagentCategory", null)
                        .WithMany()
                        .HasForeignKey("ReagentCategoryId")
                        .IsRequired()
                        .HasConstraintName("ReagentCategoryReagents_ReagentCategoryId_fkey");

                    b.HasOne("Delta.Data.Reagent", null)
                        .WithMany()
                        .HasForeignKey("ReagentId")
                        .IsRequired()
                        .HasConstraintName("ReagentCategoryReagents_ReagentId_fkey");
                });

            modelBuilder.Entity("Delta.Data.Company", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("Reagents");
                });

            modelBuilder.Entity("Delta.Data.Product", b =>
                {
                    b.Navigation("ProductImages");
                });

            modelBuilder.Entity("Delta.Data.ProductCategory", b =>
                {
                    b.Navigation("InverseParentCategory");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
