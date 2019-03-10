using System;
using LeanMobile.Algorithms;

namespace LeanMobile.Algorithms
{
    public interface IAlgorithmResultProvider
    {
        event EventHandler<AlgorithmResultEventArgs> AlgorithmResultReceived;
    }
}