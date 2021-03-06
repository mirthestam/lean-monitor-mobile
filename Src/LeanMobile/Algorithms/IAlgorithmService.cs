﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LeanMobile.Algorithms.Results;

namespace LeanMobile.Algorithms
{
    public interface IAlgorithmService
    {
        IObservable<AlgorithmResult> AlgorithmResults { get; }

        IObservable<IEnumerable<Algorithm>> GetAlgorithms();

        IObservable<Algorithm> GetAlgorithm(AlgorithmId algorithmId);

        void Subscribe(AlgorithmId algorithmId, ResultSubscriptionType resultSubscriptionType);

        void UnsubscribeAll();
    }
}