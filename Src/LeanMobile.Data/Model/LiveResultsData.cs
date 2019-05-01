using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NullGuard;

namespace LeanMobile.Data.Model
{
    public class LiveResultsData
    {
        [JsonProperty(PropertyName = "version")]
        public int Version { get; set; }

        [JsonProperty(PropertyName = "resolution"), JsonConverter(typeof(StringEnumConverter))]
        public Resolution Resolution { get; set; }

        [AllowNull]
        [JsonProperty(PropertyName = "results")]
        public LiveResult Results { get; set; }
    }
}