using System;

namespace FuzzyString.Algorithms
{
    //https://en.wikipedia.org/wiki/Levenshtein_distance
    public static class LevenshteinDistance
    {
        /// <summary>
        /// Calculate the minimum number of single-character edits needed to change the source into the target
        /// For example: source abcd and target bcde will give back value 2 (1 forr adding a and 1 for removing e
        /// </summary>
        /// <returns>The number of edits required to transform the source into the target. This is at most the length of the longest string, and at least the difference in length between the two strings</returns>
        public static int Calculate(string source, string target)
        {
            if (source.Length == 0)
                return target.Length;

            if (target.Length == 0)
                return source.Length;

            var distance = 0;
            if (source[source.Length - 1] == target[target.Length - 1])
                distance = 0;
            else
                distance = 1;

            var sourceInitial = source.Substring(0, source.Length - 1);
            var targetInitial = target.Substring(0, target.Length - 1);

            return Math.Min(Math.Min(Calculate(sourceInitial, target) + 1, Calculate(source, targetInitial)) + 1, Calculate(sourceInitial, targetInitial) + distance);
        }

        public static int CalculateUpperBounds(string source, string target)
        {
            if (source.Length > target.Length || source.Length == target.Length)
                return source.Length;

            if (target.Length > source.Length)
                return target.Length;

            return int.MaxValue;
        }
    }
}
