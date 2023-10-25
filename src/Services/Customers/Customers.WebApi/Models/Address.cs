using MongoDB.Bson.Serialization.Attributes;

namespace Customers.WebApi.Models;

public class Address
{

    [BsonElement("addressLine")]
    public string AddressLine { get; set; }

    [BsonElement("city")]
    public string City { get; set; }

    [BsonElement("country")] 
    public string Country { get; set; }

    [BsonElement("cityCode")] 
    public int CityCode { get; set; }
}
