using System;
using System.Collections.Generic;
using NullGuard;

namespace LeanMobile.Data.Model
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
        public IList<Order> Orders { get; set; }

        [AllowNull]
        public IDictionary<DateTime, decimal> ProfitLoss { get; set; }

        [AllowNull]
        public IDictionary<string, string> Statistics { get; set; }

        [AllowNull]
        public IDictionary<string, string> RuntimeStatistics { get; set; }
    }
}