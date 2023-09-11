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

    
    
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=DefaultConnection");
}
