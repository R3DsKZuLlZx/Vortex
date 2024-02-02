using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using VortexDb;

namespace ConsoleApp;

public class VortexDbContextFactory : IDesignTimeDbContextFactory<VortexDbContext>
{
    public VortexDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<VortexDbContext>();
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Integrated Security=true;Database=VortexDb");
        return new VortexDbContext(optionsBuilder.Options);
    }
}
