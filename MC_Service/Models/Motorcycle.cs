using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MC_Service.Models;

public class Motorcycle
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId _id { get; set; }
    public string Name { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }

    public Motorcycle(string name, string make, string model)
    {
        Name = name;
        Make = make;
        Model = model;
    }


}
