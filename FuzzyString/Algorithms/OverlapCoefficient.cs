using System;
using System.Linq;

namespace FuzzyString.Algorithms
{
    /// <summary>
    /// https://en.wikipedia.org/wiki/Overlap_coefficient
    /// </summary>
    public class OverlapCoefficient : BaseAlgorithm
    {
        public override double Calculate(string source, string target)
        {
            return CalculateOverlapCoefficient(source, target);
        }

        private double CalculateOverlapCoefficient(string source, string target)
        {
            return (Convert.ToDouble(source.Intersect(target).Count())) / Convert.ToDouble(Math.Min(source.Length, target.Length));
        }
    }
}
