﻿using Core.Interfaces.Entidades;
using Core.Interfaces.Repository;
using MongoDB.Driver;

namespace LocalizacaoService._03_Repositorys;

public class BaseRepository<T> : IBaseRepository<T> where T : IEntity
{
    protected readonly IMongoCollection<T> _collection;

    public BaseRepository(IMongoDatabase database, string collectionName)
    {
        try
        {
            _collection = database.GetCollection<T>(collectionName);
        }
        catch (MongoBulkWriteException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<List<T>> GetAllAsync()
    {
        try
        {
            return await _collection.Find(_ => true).ToListAsync();
        }
        catch (MongoBulkWriteException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<T> GetByIdAsync(string id)
    {
        try
        {
            return await _collection.Find(entity => entity.Id == id).FirstOrDefaultAsync();
        }
        catch (MongoBulkWriteException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task CreateAsync(T entity)
    {
        try
        {
            await _collection.InsertOneAsync(entity);
        }

        catch (MongoBulkWriteException ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public async Task InsertManyAsync(IEnumerable<T> entities)
    {
        try
        {
            await _collection.InsertManyAsync(entities);
        }
        catch (MongoBulkWriteException ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public async Task<DeleteResult> DeleteManyAsync(FilterDefinition<T> filter = null)
    {
        try
        {
            if(filter == null)
            {
                filter = Builders<T>.Filter.Empty;
            }
            var result = await _collection.DeleteManyAsync(filter);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao excluir documentos: " + ex.Message);
        }
    }
}
