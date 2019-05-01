using System.Collections.Generic;
using Newtonsoft.Json;

namespace LeanMobile.Data.Model.Responses
{
    /// <summary>
    /// Logs from a live algorithm
    /// </summary>
    public class LiveLogResponse : RootResponse
    {
        /// <summary>
        /// List of logs from the live algorithm
        /// </summary>
        [JsonProperty(PropertyName = "LiveLogs")]
        public List<string> Logs { get; set; }
    }
}