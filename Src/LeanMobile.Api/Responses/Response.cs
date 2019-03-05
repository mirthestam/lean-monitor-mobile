using System.Collections.Generic;
using Newtonsoft.Json;

namespace QuantConnect.Api.Responses
{
    public class Response
    {
        [JsonProperty(PropertyName = "success")]
        public bool Success;

        [JsonProperty(PropertyName = "errors")]
        public List<string> Errors;
    }
}