using Core.Entidades;

namespace DTOs.TablesModel;

public class CreateTableModelDTO
{
    public List<CreateColunaDTO> Colunas { get; set; } = new List<CreateColunaDTO>();
    public List<Linha> Linhas { get; set; } = new List<Linha>();
}
