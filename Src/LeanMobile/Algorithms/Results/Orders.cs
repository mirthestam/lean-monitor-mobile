using NullGuard;
using System;
using System.Collections.Generic;

namespace LeanMobile.Algorithms.Results
{
    public class Orders : AlgorithmResultBase
    {
        public List<Order> Items { get; set; } = new List<Order>();
    }
}