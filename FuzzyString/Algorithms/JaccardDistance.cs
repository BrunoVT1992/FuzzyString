using System;
using System.Linq;

namespace FuzzyString.Algorithms
{
    //https://en.wikipedia.org/wiki/Jaccard_index
    public static class JaccardDistance
    {
        /// <summary>
        /// Returns a number that displays the similarity between the 2 strings
        /// </summary>
        public static double Calculate(string source, string target)
        {
            return 1 - CalculateIndex(source, target);
        }

        public static double CalculateIndex(string source, string target)
        {
            return (Convert.ToDouble(source.Intersect(target).Count())) / (Convert.ToDouble(source.Union(target).Count()));
        }
    }
}
