using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeanMobile.Algorithms
{
    public interface IAlgorithmService
    {
        IObservable<AlgorithmResult> AlgorithmResults { get; }

        IObservable<IEnumerable<Algorithm>> GetAlgorithms();

        IObservable<Algorithm> GetAlgorithm(string algorithmId);
    }
}