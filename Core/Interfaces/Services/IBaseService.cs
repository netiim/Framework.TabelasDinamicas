using Core.Interfaces.Entidades;
using MongoDB.Driver;

namespace Core.Interfaces.Services
{
    public interface IBaseService<T> where T : IEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task CreateAsync(T entity);
        Task InsertManyAsync(IEnumerable<T> entities);
        Task DeleteById(string id);
    }
}