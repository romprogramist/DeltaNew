using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Delta.Models;

namespace Delta.Data;

public class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options)
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
}


