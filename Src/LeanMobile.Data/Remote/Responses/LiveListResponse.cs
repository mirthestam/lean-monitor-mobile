using System.Collections.Generic;
using Newtonsoft.Json;

namespace LeanMobile.Data.Remote.Responses
{
    public class LiveListResponse : Response
    {
        [JsonProperty(PropertyName = "live")]
        public List<LiveAlgorithmResponse> Algorithms;
    }
}