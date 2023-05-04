using Microsoft.EntityFrameworkCore;

namespace Delta.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    
    public DbSet<ClientApplication> ClientApplications { get; set; }
    public DbSet<Review> Reviews { get; set; }
}