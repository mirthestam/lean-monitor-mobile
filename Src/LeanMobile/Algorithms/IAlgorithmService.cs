using System;

namespace LeanMobile.Algorithms
{
    public interface IAlgorithmService
    {
        IObservable<AlgorithmResult> AlgorithmResults { get; }
    }
}