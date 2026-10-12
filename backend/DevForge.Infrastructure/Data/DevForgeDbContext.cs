using DevForge.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevForge.Infrastructure.Data; // <-- Asegúrate de que el namespace coincida con la ruta

public class DevForgeDbContext : DbContext
{
    public DevForgeDbContext(DbContextOptions<DevForgeDbContext> options) : base(options) { }

    public DbSet<RetoDev> RetosDev { get; set; } = null!;
}