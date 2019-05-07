using Newtonsoft.Json;

namespace LeanMobile.Data.Model
{
    public class Point
    {
        [JsonProperty("x")]
        public long X { get; set; }

        [JsonProperty("y")]
        public decimal? Y { get; set; }

    }
}