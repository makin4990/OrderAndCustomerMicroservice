using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Customers.WebApi.Models;

public class Customer
{
    [BsonId]
    public Guid Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("email")]
    public string Email { get; set; }

    [BsonElement("address")]
    public Address Address { get; set; }

    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; set; }
    [BsonElement("updatedAt")]

    public DateTime UpdatedAt { get; set; }

}