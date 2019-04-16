using System;
using System.Collections.Generic;

namespace LeanMobile.Algorithms
{
    [Flags]
    public enum ResultSubscriptionType
    {
        None = 0,
        LiveResults = 1,
        Log = 2,
        All = ~0,
    }

    public struct AlgorithmId : IEquatable<AlgorithmId>
    {
        public string DeployId { get; set;}

        public int ProjectId { get; set;}

        public override bool Equals(object obj)
        {
            return obj is AlgorithmId id && Equals(id);
        }

        public bool Equals(AlgorithmId other)
        {
            return DeployId == other.DeployId
                   && ProjectId == other.ProjectId;
        }

        public override int GetHashCode()
        {
            var hashCode = 1419081662;
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(DeployId);
            return (hashCode * -1521134295) + ProjectId.GetHashCode();
        }

        public static bool operator ==(AlgorithmId left, AlgorithmId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AlgorithmId left, AlgorithmId right)
        {
            return !(left == right);
        }
    }

    public class Algorithm
    {
        public AlgorithmId Id { get; set; }

        public string Name { get; set; }

        public AlgorithmStatus Status { get; set; }

        public DateTime LaunchedDateTime { get; set; }
    }
}