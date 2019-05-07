using System.Collections.Generic;
using NullGuard;

namespace LeanMobile.Data.Model
{
    public class Chart
    {
        public string Name { get; set; }

        [AllowNull]
        public IDictionary<string, Series> Series { get; set; }
    }
}