using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeanMobile.Algorithms
{
    public interface IAlgorithmRepository
    {
        Task<IEnumerable<Algorithm>> GetAlgorithmsAsync();
        Task<Algorithm> GetAlgorithmAsync(string algorithmId);
    }
}