using NullGuard;
using System;
using System.Collections.Generic;

namespace LeanMobile.Algorithms.Results
{
    public class Statistics : AlgorithmResultBase
    {
        public decimal Unrealized { get; set; }

        public decimal Fees { get; set; }

        public decimal NetProfit { get; set; }

        public decimal ReturnPercentage { get; set; }

        public decimal Equity { get; set; }

        public decimal Holdings { get; set; }

        public decimal Volume { get; set; }
    }
}