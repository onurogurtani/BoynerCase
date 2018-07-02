using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BoynerCase.Mongo.Entity
{
    public class Product
    {
        [BsonId]
        public ObjectId RecordId { get; set; }

        [BsonElement("Id")]
        public int Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("brand")]
        public string Brand { get; set; }

        [BsonElement("price")]
        public decimal Price { get; set; }

        [BsonElement("details")]
        public string Details { get; set; }
    }
}
