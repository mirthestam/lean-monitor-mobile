using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LeanMobile.Algorithms;
using LeanMobile.Algorithms.Results;
using LeanMobile.Data.Model.Responses;
using LeanMobile.Data.Utils;
using LeanMobile.Settings;

namespace LeanMobile.Data.Algorithm
{
    public abstract class AlgorithmResultProviderBase : IAlgorithmResultProvider
    {
        protected readonly Dictionary<AlgorithmId, ResultSubscriptionType> _subscriptions = new Dictionary<AlgorithmId, ResultSubscriptionType>();

        public event EventHandler<AlgorithmResultEventArgs> AlgorithmResultReceived;

        public abstract void Run();

        public abstract void Abort();

        protected virtual void OnAlgorithmResultUpdated(AlgorithmResultEventArgs e)
        {
            AlgorithmResultReceived?.Invoke(this, e);
        }

        public void Subscribe(AlgorithmId algorithmId, ResultSubscriptionType resultSubscriptionType)
        {
            lock (_subscriptions)
            {
                if (_subscriptions.TryGetValue(algorithmId, out ResultSubscriptionType newSubscription))
                {
                    newSubscription &= resultSubscriptionType;
                }
                else
                {
                    newSubscription = resultSubscriptionType;
                }

                _subscriptions[algorithmId] = newSubscription;
            }
        }

        public void Unsubscribe(AlgorithmId algorithmId, ResultSubscriptionType resultSubscriptionType = ResultSubscriptionType.All)
        {
            lock (_subscriptions)
            {
                if (resultSubscriptionType == ResultSubscriptionType.All)
                {
                    _subscriptions.Remove(algorithmId);
                }
                else
                {
                    var subscription = _subscriptions[algorithmId];
                    subscription &= ~resultSubscriptionType;
                }
            }
        }

        public void ClearSubscriptions()
        {
            lock (_subscriptions)
            { 
                _subscriptions.Clear();
            }
        }
    }
}
