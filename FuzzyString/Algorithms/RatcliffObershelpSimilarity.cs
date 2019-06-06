using System;
using System.Linq;

namespace FuzzyString.Algorithms
{
    /// <summary>
    /// https://www.morfoedro.it/doc.php?n=223&lang=en
    /// </summary>
    public class RatcliffObershelpSimilarity : BaseAlgorithm
    {
        public override double Calculate(string source, string target)
        {
            return CalculateRatcliffObershelpSimilarity(source, target);
        }

        private double CalculateRatcliffObershelpSimilarity(string source, string target)
        {
            return (2 * Convert.ToDouble(source.Intersect(target).Count())) / (Convert.ToDouble(source.Length + target.Length));
        }
    }
}
