using System;
using Newtonsoft.Json;

namespace LeanMobile.Data.Remote.Responses
{
    public class LiveAlgorithmResponse : Response
    {
        /* The following field(s) are present in the response, however not 'documented' in the official API client'
         - None
         */

        /* The following field(s) are documented but ignored or simplified in this implementation
         - None
         */

        [JsonProperty(PropertyName = "projectId")]
        public int ProjectId;

        [JsonProperty(PropertyName = "deployId")]
        public string DeployId;

        [JsonProperty(PropertyName = "status")]
        public AlgorithmStatus Status;

        [JsonProperty(PropertyName = "launched")]
        public DateTime Launched;

        [JsonProperty(PropertyName = "stopped")]
        public DateTime? Stopped;

        [JsonProperty(PropertyName = "brokerage")]
        public string Brokerage;

        [JsonProperty(PropertyName = "subscription")]
        public string Subscription;

        [JsonProperty(PropertyName = "error")]
        public string Error;
    }
}