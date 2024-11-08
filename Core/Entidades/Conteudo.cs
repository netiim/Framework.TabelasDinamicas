using MongoDB.Bson.Serialization.IdGenerators;

namespace Core.Entidades;

public class Conteudo
{
    public Dictionary<string, string> ConteudoValue { get; set; } = new Dictionary<string, string>();
}
