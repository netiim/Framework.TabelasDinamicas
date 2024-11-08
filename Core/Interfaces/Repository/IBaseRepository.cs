using Core.Interfaces.Entidades;
using MongoDB.Driver;

namespace Core.Interfaces.Repository;

public interface IBaseRepository<T> where T : IEntity
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(string id);
    Task CreateAsync(T entity);
    Task InsertManyAsync(IEnumerable<T> entities);
    Task<DeleteResult> DeleteManyAsync(FilterDefinition<T> filter = null);
}
