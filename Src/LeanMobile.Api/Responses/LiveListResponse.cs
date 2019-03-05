using System.Collections.Generic;
using Newtonsoft.Json;

namespace QuantConnect.Api.Responses
{
    public class LiveListResponse : Response
    {
        [JsonProperty(PropertyName = "live")]
        public List<LiveAlgorithmResponse> Algorithms;
    }
}