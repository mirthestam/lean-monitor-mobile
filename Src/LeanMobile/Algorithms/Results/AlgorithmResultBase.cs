using NullGuard;
using System;
using System.Collections.Generic;

namespace LeanMobile.Algorithms.Results
{
    public abstract class AlgorithmResultBase
    {
        public DateTime DateUpdated { get; set; } = DateTime.MinValue;
    }
}