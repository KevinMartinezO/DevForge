using DevForge.Domain.Entities;

namespace DevForge.Application.Interfaces;

public interface IRetoDevRepository
{
    Task<IEnumerable<RetoDev>> GetAllAsync();
    Task<RetoDev?> GetByIdAsync(int id); 
    Task<RetoDev> AddAsync(RetoDev reto);
    Task UpdateAsync(RetoDev reto);      
    Task DeleteAsync(RetoDev reto);      
}