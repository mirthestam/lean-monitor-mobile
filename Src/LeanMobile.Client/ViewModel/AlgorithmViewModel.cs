using LeanMobile.Algorithms;

namespace LeanMobile.Client.ViewModel
{
    public class AlgorithmViewModel
    {
        private readonly Algorithm _algorithm;

        public AlgorithmViewModel(Algorithm algorithm)
        {
            _algorithm = algorithm;
        }

        public string Id => _algorithm.Id;
        public string Name => _algorithm.Name;

        public decimal Unrealized { get; set; }
        public decimal Equity { get; set; }
        public decimal Holdings { get; set; }
    }
}