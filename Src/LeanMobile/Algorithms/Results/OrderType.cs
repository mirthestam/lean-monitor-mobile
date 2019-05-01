using NullGuard;
using System;
using System.Collections.Generic;

namespace LeanMobile.Algorithms.Results
{
    public enum OrderType
    {
        Market,
        Limit,
        StopMarket,
        StopLimit,
        MarketOnOpen,
        MarketOnClose,
        OptionExercise
    }
}