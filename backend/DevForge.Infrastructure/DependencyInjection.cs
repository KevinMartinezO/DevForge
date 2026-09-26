using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DevForge.Application.Interfaces;
using DevForge.Infrastructure.Data;
using DevForge.Infrastructure.Repositories;

namespace DevForge.Infrastructure;

public static class DependencyInjection 
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString) 
    {
        // 1. Configuración del DbContext con PostgreSQL
        services.AddDbContext<DevForgeDbContext>(options =>
            options.UseNpgsql(connectionString));

        // 2. Registro del repositorio
        services.AddScoped<IRetoDevRepository, RetoDevRepository>();

        return services;
    }
}