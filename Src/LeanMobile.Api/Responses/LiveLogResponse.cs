using System.Collections.Generic;
using Newtonsoft.Json;

namespace QuantConnect.Api.Responses
{
    /// <summary>
    /// Logs from a live algorithm
    /// </summary>
    public class LiveLogResponse : Response
    {
        /// <summary>
        /// List of logs from the live algorithm
        /// </summary>
        [JsonProperty(PropertyName = "LiveLogs")]
        public List<string> Logs { get; set; }
    }
}