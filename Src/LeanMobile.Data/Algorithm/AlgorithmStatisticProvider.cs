using System;
using System.Collections.Generic;
using System.Text;
using LeanMobile.Algorithms;

namespace LeanMobile.Data
{
    public class AlgorithmResultProvider : IAlgorithmResultProvider
    {
        public event EventHandler<AlgorithmResultEventArgs> AlgorithmResultReceived;

        protected virtual void OnAlgorithmResultUpdated(AlgorithmResultEventArgs e)
        {
            AlgorithmResultReceived?.Invoke(this, e);
        }
    }
}
