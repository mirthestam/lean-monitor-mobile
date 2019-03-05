using System;
using Newtonsoft.Json;

namespace QuantConnect.Api.Responses
{
    public class LiveAlgorithmResponse : Response
    {
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