using Microsoft.EntityFrameworkCore;
using workshop.data.models;

namespace workshop.data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    public DbSet<Calculation> Calculations { get; set; }
}
