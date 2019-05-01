using LeanMobile.Algorithms.Results;
using LeanMobile.Data.Model.Responses;

namespace LeanMobile.Data.Algorithm
{
    public interface IApiResultParser
    {
        void ProcessLiveResult(AlgorithmResult result, LiveAlgorithmResultsResponse response);
    }
}