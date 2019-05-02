using System;
using System.Threading.Tasks;

namespace LeanMobile.Algorithms.Results
{
    public interface IAlgorithmResultProvider
    {
        event EventHandler<AlgorithmResultEventArgs> AlgorithmResultReceived;

        void Run();

        Task Subscribe(AlgorithmId algorithmId, ResultSubscriptionType resultSubscriptionType);

        void ClearSubscriptions();
    }
}