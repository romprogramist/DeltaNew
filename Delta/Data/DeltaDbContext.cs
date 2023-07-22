using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Delta.Data;

public partial class DeltaDbContext : DbContext
{
    public DeltaDbContext()
    {
    }

    public DeltaDbContext(DbContextOptions<DeltaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Certificate> Certificates { get; set; }

    public virtual DbSet<ClientApplication> ClientApplications { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Consumable> Consumables { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductImage> ProductImages { get; set; }

    public virtual DbSet<Reagent> Reagents { get; set; }

    public virtual DbSet<ReagentCategory> ReagentCategories { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }
    
    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Certificate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Certificates_pkey");

            entity.Property(e => e.Image).HasMaxLength(32);
            entity.Property(e => e.Pdf).HasMaxLength(32);

            entity.HasMany(d => d.Products).WithMany(p => p.Certificates)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductCertificate",
                    r => r.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("ProductCertificates_ProductId_fkey"),
                    l => l.HasOne<Certificate>().WithMany()
                        .HasForeignKey("CertificateId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("ProductCertificates_CertificateId_fkey"),
                    j =>
                    {
                        j.HasKey("CertificateId", "ProductId").HasName("ProductCertificatesPKey");
                        j.ToTable("ProductCertificate");
                        j.HasIndex(new[] { "ProductId" }, "IX_ProductCertificate_ProductId");
                    });
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Companies_pkey");

            entity.Property(e => e.Logo).HasMaxLength(32);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Consumable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Consumables_pkey");

            entity.Property(e => e.Name).HasMaxLength(80);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Products_pkey");

            entity.HasIndex(e => e.CompanyId, "IX_Products_CompanyId");

            entity.HasIndex(e => e.ProductCategoriesId, "IX_Products_ProductCategoriesId");

            entity.Property(e => e.CardTitle).HasMaxLength(150);
            entity.Property(e => e.LongNamePrefix).HasMaxLength(100);
            entity.Property(e => e.Model).HasMaxLength(60);
            entity.Property(e => e.ModelSeries).HasMaxLength(64);
            entity.Property(e => e.Url).HasMaxLength(64);

            entity.HasOne(d => d.Company).WithMany(p => p.Products)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CompanyId");

            entity.HasOne(d => d.ProductCategories).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductCategoriesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ProductCategoriesId");

            entity.HasMany(d => d.Consumables).WithMany(p => p.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductConsumable",
                    r => r.HasOne<Consumable>().WithMany()
                        .HasForeignKey("ConsumableId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("ProductConsumables_ConsumableId_fkey"),
                    l => l.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("ProductConsumables_ProductId_fkey"),
                    j =>
                    {
                        j.HasKey("ProductId", "ConsumableId").HasName("ProductConsumablesPKey");
                        j.ToTable("ProductConsumable");
                        j.HasIndex(new[] { "ConsumableId" }, "IX_ProductConsumable_ConsumableId");
                    });
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ProductCategories_pkey");

            entity.HasIndex(e => e.ParentCategoryId, "IX_ProductCategories_ParentCategoryId");

            entity.Property(e => e.Image).HasMaxLength(32);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Url).HasMaxLength(64);

            entity.HasOne(d => d.ParentCategory).WithMany(p => p.InverseParentCategory)
                .HasForeignKey(d => d.ParentCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ParentCategoryId");
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ProductImages_pkey");

            entity.HasIndex(e => e.ProductId, "IX_ProductImages_ProductId");

            entity.Property(e => e.Url).HasMaxLength(32);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductImages)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ProductImages_ProductId_fkey");
        });

        modelBuilder.Entity<Reagent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Reagents_pkey");

            entity.HasIndex(e => e.CompanyId, "IX_Reagents_CompanyId");

            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Company).WithMany(p => p.Reagents)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Reagents_CompanyId_fkey");

            entity.HasMany(d => d.Products).WithMany(p => p.Reagents)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductReagent",
                    r => r.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("ProductReagents_ProductId_fkey"),
                    l => l.HasOne<Reagent>().WithMany()
                        .HasForeignKey("ReagentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("ProductReagents_ReagentId_fkey"),
                    j =>
                    {
                        j.HasKey("ReagentId", "ProductId").HasName("ProductReagentsPKey");
                        j.ToTable("ProductReagent");
                        j.HasIndex(new[] { "ProductId" }, "IX_ProductReagent_ProductId");
                    });
        });

        modelBuilder.Entity<ReagentCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ReagentCategories_pkey");

            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasMany(d => d.Reagents).WithMany(p => p.ReagentCategories)
                .UsingEntity<Dictionary<string, object>>(
                    "ReagentCategoryReagent",
                    r => r.HasOne<Reagent>().WithMany()
                        .HasForeignKey("ReagentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("ReagentCategoryReagents_ReagentId_fkey"),
                    l => l.HasOne<ReagentCategory>().WithMany()
                        .HasForeignKey("ReagentCategoryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("ReagentCategoryReagents_ReagentCategoryId_fkey"),
                    j =>
                    {
                        j.HasKey("ReagentCategoryId", "ReagentId").HasName("ReagentCategoryReagentsPKey");
                        j.ToTable("ReagentCategoryReagent");
                        j.HasIndex(new[] { "ReagentId" }, "IX_ReagentCategoryReagent_ReagentId");
                    });
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.Property(e => e.CreationDateTime).HasDefaultValueSql("'-infinity'::timestamp with time zone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
