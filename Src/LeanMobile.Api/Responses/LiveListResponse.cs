using System.Collections.Generic;
using Newtonsoft.Json;

namespace LeanMobile.Api.Responses
{
    public class LiveListResponse : Response
    {
        [JsonProperty(PropertyName = "live")]
        public List<LiveAlgorithmResponse> Algorithms;
    }
}