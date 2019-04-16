using NullGuard;
using System;
using System.Collections.Generic;

namespace LeanMobile.Algorithms.Results
{
    public class AlgorithmResult
    {
        public AlgorithmId AlgorithmId { get; set; }

        [AllowNull]
        public ServerStatistics ServerStatistics {get; set; }

        [AllowNull]
        public Statistics Statistics { get; set; }

        [AllowNull]
        public List<string> Log { get; set;}
    }

    public class Statistics
    {
        public decimal Unrealized { get; set; }

        public decimal Fees { get; set; }

        public decimal NetProfit { get; set; }

        public decimal ReturnPercentage { get; set; }

        public decimal Equity { get; set; }

        public decimal Holdings { get; set; }

        public decimal Volume { get; set; }
    }

    public class ServerStatistics
    {
        public int CpuUsage { get; set; }

        public int MemoryUsed { get; set; }

        public int MemoryTotal { get; set; }

        public TimeSpan Uptime { get; set; }
    }
}