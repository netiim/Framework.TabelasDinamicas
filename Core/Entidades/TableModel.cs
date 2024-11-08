using Core.Interfaces.Entidades;

namespace Core.Entidades;

public class TableModel : EntityBase, IEntity
{
    public List<Coluna> Colunas { get; set; } = new List<Coluna>();
    public List<Linha> Linhas { get; set; } = new List<Linha>();
}
