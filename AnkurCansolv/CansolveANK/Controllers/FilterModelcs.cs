using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CansolveANK.Controllers
{
    public class FilterModelcs
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ? id { get; set; }
        public string? TagName { get; set; }
        public Double ? Value{ get; set; }

        public DateTime ? EventTime{ get; set; }
    }
}
