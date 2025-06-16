using MCPServer.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MCPServer.API.Data;

public class ApiDbContext : DbContext
{
    public DbSet<Pessoa> Pessoas { get; set; }

    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
