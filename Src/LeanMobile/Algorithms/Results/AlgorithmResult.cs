using NullGuard;
using System;
using System.Collections.Generic;

namespace LeanMobile.Algorithms.Results
{
    public class AlgorithmResult
    {
        public AlgorithmId AlgorithmId { get; set; }

        [AllowNull]
        public ServerStatistics ServerStatistics { get; set; }

        [AllowNull]
        public Statistics Statistics { get; set; }

        [AllowNull]
        public Orders Orders { get; set;}

        [AllowNull]
        public Log Log { get; set; }
    }
}