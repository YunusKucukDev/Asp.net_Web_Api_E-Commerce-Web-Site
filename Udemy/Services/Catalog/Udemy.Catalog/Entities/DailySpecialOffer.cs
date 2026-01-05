using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Udemy.Catalog.Entities
{
    public class DailySpecialOffer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string DailyspecialOfferId { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string ImageUrl { get; set; }
    }
}
