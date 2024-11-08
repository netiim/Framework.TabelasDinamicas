using Core.Entidades;
using Core.Interfaces;
using Core.Interfaces.Repository;
using LocalizacaoService._03_Repositorys;
using MongoDB.Driver;

namespace Dados.Repositorio;

public class TableModelRepository : BaseRepository<TableModel>, ITableModelRepository
{
    public TableModelRepository(IMongoDatabase database)
           : base(database, "TableModel") { }
}
