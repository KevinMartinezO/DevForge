using Microsoft.EntityFrameworkCore;
using DevForge.Domain.Entities;

namespace DevForge.Infrastructure.Data;

public class DevForgeDbContext : DbContext 
{
    public DevForgeDbContext(DbContextOptions<DevForgeDbContext> options) : base(options) { }
    
    public DbSet<RetoDev> RetosDev { get; set; }
}