using NullGuard;
using System;
using System.Collections.Generic;

namespace LeanMobile.Algorithms.Results
{
    public class ServerStatistics : AlgorithmResultBase
    {
        public int CpuUsage { get; set; }

        public int MemoryUsed { get; set; }

        public int MemoryTotal { get; set; }

        public TimeSpan Uptime { get; set; }
    }
}