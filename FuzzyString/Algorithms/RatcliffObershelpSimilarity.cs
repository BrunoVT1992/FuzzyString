using System;
using System.Linq;

namespace FuzzyString.Algorithms
{
    //https://www.morfoedro.it/doc.php?n=223&lang=en
    public static class RatcliffObershelpSimilarity
    {
        public static double Calculate(string source, string target)
        {
            return (2 * Convert.ToDouble(source.Intersect(target).Count())) / (Convert.ToDouble(source.Length + target.Length));
        }
    }
}
