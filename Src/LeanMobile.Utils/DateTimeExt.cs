using System;
using System.Collections.Generic;
using System.Text;

namespace LeanMobile.Utils
{
    public static class DateTimeExt
    {
        public static double ToUnixTimeStamp(this DateTime dateTime)
        {
            return (dateTime - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds;
        }
    }
}
