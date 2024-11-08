using Core.Entidades;
using Core.Interfaces.Repository;
using Core.Interfaces.Services;

namespace Services;

public class TableModelService : BaseService<TableModel>, ITableModelService
{
    public TableModelService(ITableModelRepository repository)
           : base(repository) { }

    //public override async Task CreateAsync(CreateTableModelDTO)
    //{
    //    await _repository.CreateAsync(entity);
    //}
}
