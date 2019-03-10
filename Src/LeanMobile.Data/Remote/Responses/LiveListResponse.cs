using System.Collections.Generic;
using Newtonsoft.Json;

namespace LeanMobile.Data.Remote.Responses
{
    public class LiveListResponse : RootResponse
    {
        [JsonProperty(PropertyName = "live")]
        public List<LiveAlgorithmResponse> Algorithms;
    }
}