using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Udemy.Catalog.Entities
{
    public class ProductDetail
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductDetailId { get; set; }
        public string ProductDesciption { get; set; }
        public string ProductInfo { get; set; }

        public string ProductId { get; set; }
        [BsonIgnore]
        public Product Product { get; set; }
    }
}
