using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeanMobile.Algorithms;

namespace LeanMobile.Data.Algorithm
{
    public class AlgorithmRepository : IAlgorithmRepository
    {
        public Task<IEnumerable<Algorithms.Algorithm>> GetAlgorithmsAsync()
        {
            var algorithms = new List<Algorithms.Algorithm>
            {
                new Algorithms.Algorithm
                {
                    Id = 3,
                    LaunchedDateTime = DateTime.Now,
                    Name = "Foo",
                    Status = AlgorithmStatus.Running
                }
            };

            return Task.FromResult(algorithms.AsEnumerable());
        }
    }
}