using System.Collections.Generic;
using Newtonsoft.Json;

namespace LeanMobile.Data.Model.Responses
{
    public class LiveListResponse : RootResponse
    {
        [JsonProperty(PropertyName = "live")]
        public List<LiveAlgorithmResponse> Algorithms;
    }
}