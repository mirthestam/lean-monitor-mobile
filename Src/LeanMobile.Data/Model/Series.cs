using System.Collections.Generic;
using NullGuard;

namespace LeanMobile.Data.Model
{
    public class Series
    {
        public string Name { get; set; }

        [AllowNull]
        public IList<Point> Values { get; set; }
    }
}