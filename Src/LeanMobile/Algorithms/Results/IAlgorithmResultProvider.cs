using System;

namespace LeanMobile.Algorithms.Results
{
    public interface IAlgorithmResultProvider
    {
        event EventHandler<AlgorithmResultEventArgs> AlgorithmResultReceived;

        void Run();
        void Abort();

        void Subscribe(AlgorithmId algorithmId, ResultSubscriptionType resultSubscriptionType);

        void Unsubscribe(AlgorithmId algorithmId, ResultSubscriptionType resultSubscriptionType = ResultSubscriptionType.All);

        void ClearSubscriptions();
    }
}