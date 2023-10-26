using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using ThirdParty.Json.LitJson;
using JsonPropertyAttribute = ThirdParty.Json.LitJson.JsonPropertyAttribute;

namespace CansolveANK.CansolveModel
{
    [BsonIgnoreExtraElements]
    public class Cansolve
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [Newtonsoft.Json.JsonProperty("TagName")]
        public string ? TagName { get; set; }

        [Newtonsoft.Json.JsonProperty("EventTime")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime ? EventTime { get; set; }

        [JsonIgnore]
   
        public Decimal128 ? Value { get; set; }

        [Newtonsoft.Json.JsonProperty("Value")]
        public double DoubleValue
        {
            get
            {
                return double.Parse(Value.ToString());
            }
            set
            {
                Value = Decimal128.Parse(value.ToString());
                 
            }
        }
    }

   
}
