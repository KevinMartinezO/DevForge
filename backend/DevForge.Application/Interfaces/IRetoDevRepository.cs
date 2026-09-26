using DevForge.Domain.Entities;

namespace DevForge.Application.Interfaces;

public interface IRetoDevRepository 
{
    Task<IEnumerable<RetoDev>> GetAllAsync();
}