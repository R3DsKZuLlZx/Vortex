using System.Reflection;
using Microsoft.EntityFrameworkCore;
using VortexDb.Entities;

namespace VortexDb;

public class VortexDbContext(DbContextOptions<VortexDbContext> options) : DbContext(options)
{
    public DbSet<Example> Examples { get; set; } = default!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
