using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using NodaTime;

namespace LeanMobile.Algorithms.Results
{
    public struct ChartPoint
    {
        public Instant X { get; set; }

        public decimal? Y { get; set; }

        public ChartPoint(Instant x, decimal? y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{X} - {Y}";
        }
    }
}
