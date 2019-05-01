using System;

namespace LeanMobile.Algorithms
{
    [Flags]
    public enum ResultSubscriptionType
    {
        None = 0,
        LiveResults = 1,
        Log = 2,
        All = ~0,
    }
}