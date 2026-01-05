using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Udemy.Catalog.Entities
{
    public class GeneralSpecialOffer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SpecialOfferId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageUrl { get; set; }
    }
}
