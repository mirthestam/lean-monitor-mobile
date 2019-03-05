using System.Collections.Generic;

namespace QuantConnect.Api.Responses
{
    public class LiveResult : Result
    {
        ///// <summary>
        ///// Holdings dictionary of algorithm holdings information
        ///// </summary>
        //public IDictionary<string, Holding> Holdings = new Dictionary<string, Holding>();

        ///// <summary>
        ///// Cashbook for the algorithm's live results.
        ///// </summary>
        //public CashBook Cash;

        /// <summary>
        /// Server status information, including CPU/RAM usage, ect...
        /// </summary>
        public IDictionary<string, string> ServerStatistics = new Dictionary<string, string>();
    }
}