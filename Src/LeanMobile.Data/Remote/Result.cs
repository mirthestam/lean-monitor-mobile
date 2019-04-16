using NullGuard;
using System;
using System.Collections.Generic;

namespace LeanMobile.Data.Remote
{
    public class Result
    {
        /* The following field(s) are present in the response, however not 'documented' in the official API client'
         - Not investigated
         */

        /* The following field(s) are documented but ignored or simplified in this implementation
         - IsFrameworkAlgorithm
         - AlphaRuntimeStatistics
         */

        /* The following lines need investigation, as the official client uses a custom converter to deserialize this into their model.
         However I am unsure whether we need to follow that model
         public IDictionary<string, Chart> Charts = new Dictionary<string, Chart>();
         public IDictionary<int, Order> Orders = new Dictionary<int, Order>();
         */

        [AllowNull]
        public IDictionary<DateTime, decimal> ProfitLoss { get; set; }  = new Dictionary<DateTime, decimal>();

        [AllowNull]
        public IDictionary<string, string> Statistics { get; set; } = new Dictionary<string, string>();

        [AllowNull]
        public IDictionary<string, string> RuntimeStatistics { get; set; } = new Dictionary<string, string>();
    }
}