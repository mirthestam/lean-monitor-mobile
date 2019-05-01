using System.Collections.Generic;
using NullGuard;

namespace LeanMobile.Data.Model
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

        [AllowNull]
        public IDictionary<string, Holding> Holdings { get; set; }
    }
}