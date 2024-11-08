using Core.Interfaces.Entidades;
using Core.Interfaces.Repository;
using Core.Interfaces.Services;
using MongoDB.Driver;

namespace Services;

public class BaseService<T> : IBaseService<T> where T : IEntity
{
    private readonly IBaseRepository<T> _repository;


    public BaseService(IBaseRepository<T> repository)
    {
        _repository = repository;
    }
    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }
    public virtual async Task<T> GetByIdAsync(string id)
    {
        return await _repository.GetByIdAsync(id);
    }
    public virtual async Task CreateAsync(T entity)
    {
        await _repository.CreateAsync(entity);
    }
    public virtual async Task InsertManyAsync(IEnumerable<T> entities)
    {
        await _repository.InsertManyAsync(entities);
    }
    public virtual async Task DeleteById(string id)
    {
        var filter = Builders<T>.Filter.Eq(table => table.Id, id);
        await _repository.DeleteManyAsync(filter);
    }
}