using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeanMobile.Algorithms
{
    public interface IAlgorithmService
    {
        IObservable<AlgorithmResult> AlgorithmResults { get; }

        Task<IEnumerable<Algorithm>> GetAlgorithmsAsync();

        Task<Algorithm> GetAlgorithmAsync(string algorithmId);
    }
}