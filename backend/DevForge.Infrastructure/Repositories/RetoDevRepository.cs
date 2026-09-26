using Microsoft.EntityFrameworkCore;
using DevForge.Application.Interfaces;
using DevForge.Domain.Entities;
using DevForge.Infrastructure.Data;

namespace DevForge.Infrastructure.Repositories;

public class RetoDevRepository : IRetoDevRepository 
{
    private readonly DevForgeDbContext _context;
    
    public RetoDevRepository(DevForgeDbContext context) 
    {
        _context = context;
    }

    public async Task<IEnumerable<RetoDev>> GetAllAsync() 
    {
        return await _context.RetosDev.ToListAsync();
    }
}