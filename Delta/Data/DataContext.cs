using Microsoft.EntityFrameworkCore;

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
    
}