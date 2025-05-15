using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Planet
{
    [BsonId]
    public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

    public string Name { get; set; } = string.Empty;
    public double Mass { get; set; }
}
