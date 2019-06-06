using System;
using System.Linq;

namespace FuzzyString.Algorithms
{
    /// <summary>
    /// https://en.wikipedia.org/wiki/Jaccard_index
    /// </summary>
    public class JaccardDistance : BaseAlgorithm
    {
        public override double Calculate(string source, string target)
        {
            return CalculateJaccardDistance(source, target);
        }
        private double CalculateJaccardDistance(string source, string target)
        {
            return (Convert.ToDouble(source.Intersect(target).Count())) / (Convert.ToDouble(source.Union(target).Count()));
        }
    }
}
