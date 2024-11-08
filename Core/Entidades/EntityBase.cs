using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Core.Entidades;

public abstract class EntityBase
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.Now;
}
