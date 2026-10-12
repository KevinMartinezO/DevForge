using DevForge.Application.Interfaces;
using DevForge.Domain.Entities;
using DevForge.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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

    public async Task<RetoDev?> GetByIdAsync(int id)
    {
        return await _context.RetosDev.FindAsync(id);
    }

    public async Task<RetoDev> AddAsync(RetoDev reto)
    {
        _context.RetosDev.Add(reto);
        await _context.SaveChangesAsync();
        return reto;
    }

    public async Task UpdateAsync(RetoDev reto)
    {
        _context.RetosDev.Update(reto);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(RetoDev reto)
    {
        _context.RetosDev.Remove(reto);
        await _context.SaveChangesAsync();
    }
}