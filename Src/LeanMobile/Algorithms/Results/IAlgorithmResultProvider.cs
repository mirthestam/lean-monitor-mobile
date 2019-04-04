using System;

namespace LeanMobile.Algorithms.Results
{
    public interface IAlgorithmResultProvider
    {
        event EventHandler<AlgorithmResultEventArgs> AlgorithmResultReceived;
    }
}