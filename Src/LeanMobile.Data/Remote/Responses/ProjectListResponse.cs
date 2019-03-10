using System.Collections.Generic;
using Newtonsoft.Json;

namespace LeanMobile.Data.Remote.Responses
{
    public class ProjectListResponse : RootResponse
    {
        /// <summary>
        /// List of projects for the authenticated user
        /// </summary>
        [JsonProperty(PropertyName = "projects")]
        public List<ProjectResponse> Projects;
    }
}