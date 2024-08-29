using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace MC_Service.Models;

public class Motorcycle
{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId _id { get; set; }
    [JsonPropertyName("make")]
    public string Make { get; set; }
    [JsonPropertyName("model")]
    public string Model { get; set; }
    [JsonPropertyName("type")]
    public string Type { get; set; }
    [JsonPropertyName("ccm")]
    public string Ccm { get; set; }
    [JsonPropertyName("color")]
    public string Color { get; set; }
    [JsonPropertyName("year")]
    public string Year { get; set; }

    public Motorcycle(string make, string model, string type, string ccm, string color, string year)
    {
        Make = make;
        Model = model;
        Type = type;
        Ccm = ccm;
        Color = color;
        Year = year;
    }


}
