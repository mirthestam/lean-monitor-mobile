using System.Collections.Generic;
using Newtonsoft.Json;

namespace LeanMobile.Data.Model.Responses
{
    public class RootResponse : Response
    {
        [JsonProperty(PropertyName = "success")]
        public bool Success;

        [JsonProperty(PropertyName = "errors")]
        public List<string> Errors;
    }
}