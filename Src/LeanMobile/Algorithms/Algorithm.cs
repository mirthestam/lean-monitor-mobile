using System;

namespace LeanMobile.Algorithms
{
    public class Algorithm
    {
        public AlgorithmId Id { get; set; }

        public string Name { get; set; }

        public AlgorithmStatus Status { get; set; }

        public DateTime LaunchedDateTime { get; set; }
    }
}