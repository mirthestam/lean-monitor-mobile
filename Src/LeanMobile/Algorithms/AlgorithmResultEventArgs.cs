using System;

namespace LeanMobile.Algorithms
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