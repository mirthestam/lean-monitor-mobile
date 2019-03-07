using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LeanMobile.Data.Remote
{
    public class LiveResultsData
    {
        [JsonProperty(PropertyName = "version")]
        public int Version { get; set; }

        [JsonProperty(PropertyName = "resolution"), JsonConverter(typeof(StringEnumConverter))]
        public Resolution Resolution { get; set; }

        [JsonProperty(PropertyName = "results")]
        public LiveResult Results { get; set; }
    }
}