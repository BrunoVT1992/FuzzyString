using System;
using System.Linq;

namespace FuzzyString.Algorithms
{
    //https://en.wikipedia.org/wiki/Overlap_coefficient
    public static class OverlapCoefficient
    {
        /// <summary>
        /// Gives a value between 0 and 1 that displays hom much percent the longest common substring is.
        /// </summary>
        public static double Calculate(string source, string target)
        {
            return (Convert.ToDouble(source.Intersect(target).Count())) / Convert.ToDouble(Math.Min(source.Length, target.Length));
        }
    }
}
