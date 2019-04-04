using System;

namespace LeanMobile.Algorithms.Results
{
    public class AlgorithmResultEventArgs : EventArgs
    {
        public AlgorithmResultEventArgs(AlgorithmResult result)
        {
            Result = result;
        }

        public AlgorithmResult Result { get; set; }
    }
}