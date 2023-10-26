
using Newtonsoft.Json;
using JsonPropertyAttribute = ThirdParty.Json.LitJson.JsonPropertyAttribute;

namespace CansolveANK.CansolveModel
{
    public class DoubleValueConverter  :JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((Cansolve)value).DoubleValue);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException("Deserialization is not supported.");
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Cansolve);
        }

       
    }
}
