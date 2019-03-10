using System;
using System.Diagnostics;
using Newtonsoft.Json;

namespace LeanMobile.Data.Remote.Responses
{
    [DebuggerDisplay("{ProjectId}-{Name}")]
    public class ProjectResponse : Response
    {
        /* The following field(s) are present in the response, however not 'documented' in the official API client'
         - Collaborators
         - LiveResults
         - IsAlphaStreamDeployment
         - Owner information
         */

        /* The following field(s) are documented but ignored or simplified in this implementation
         - Language
         */

        [JsonProperty(PropertyName = "projectId")]
        public int ProjectId;

        [JsonProperty(PropertyName = "name")]
        public string Name;

        [JsonProperty(PropertyName = "created")]
        public DateTime Created;

        [JsonProperty(PropertyName = "modified")]
        public DateTime Modified;
    }
}