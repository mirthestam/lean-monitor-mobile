using System.Collections.Generic;

namespace LeanMobile.Api
{
    public class Result
    {
        ///// <summary>
        ///// Charts updates for the live algorithm since the last result packet
        ///// </summary>
        //public IDictionary<string, Chart> Charts = new Dictionary<string, Chart>();

        ///// <summary>
        ///// Order updates since the last result packet
        ///// </summary>
        //public IDictionary<int, Order> Orders = new Dictionary<int, Order>();

        /// <summary>
        /// Runtime banner/updating statistics in the title banner of the live algorithm GUI.
        /// </summary>
        public IDictionary<string, string> RuntimeStatistics = new Dictionary<string, string>();
    }
}