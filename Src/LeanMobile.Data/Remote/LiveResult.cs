using NullGuard;
using System.Collections.Generic;

namespace LeanMobile.Data.Remote
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
        [AllowNull]
        public IDictionary<string, string> ServerStatistics { get; set; }
    }
}