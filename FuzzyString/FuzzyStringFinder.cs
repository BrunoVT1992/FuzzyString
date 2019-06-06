using FuzzyString.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FuzzyString
{
    public static class FuzzyStringFinder
    {
        public static string FindMatch(string source, IEnumerable<string> targets, bool caseSensitive = true, double matchStrenght = 0.66)
        {
            if (targets?.Any() != true)
                return null;

            string foundMatch = null;
            var foundMatchStrenght = 0.0;

            foreach (var target in targets)
            {
                var currentMatchStrenght = FindMatchStrenght(source, target, caseSensitive);

                if (currentMatchStrenght >= matchStrenght && currentMatchStrenght > foundMatchStrenght)
                {
                    foundMatchStrenght = currentMatchStrenght;
                    foundMatch = target;
                }
            }

            return foundMatch;
        }

        public static bool IsMatch(string source, string target, bool caseSensitive = true, double matchStrenght = 0.66)
        {
            var foundMatchStrenght = FindMatchStrenght(source, target, caseSensitive);

            return foundMatchStrenght >= matchStrenght;
        }

        private static double FindMatchStrenght(string source, string target, bool caseSensitive)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(target))
                return 0;

            if (!caseSensitive)
            {
                source = source?.ToLower();
                target = target?.ToLower();
            }

            if (source == target)
                return 1;

            var comparisonResults = new List<double>();

            if (source.Length == target.Length)
                comparisonResults.Add(1 - (HammingDistance.Calculate(source, target) / (double)target.Length));

            comparisonResults.Add(1 - JaccardDistance.Calculate(source, target));

            comparisonResults.Add(1 - Convert.ToDouble(LevenshteinDistance.Calculate(source, target)) / Convert.ToDouble(LevenshteinDistance.CalculateUpperBounds(source, target)));

            comparisonResults.Add(Convert.ToDouble(LongestCommonSubsequence.Calculate(source, target).Length) / Convert.ToDouble(Math.Min(source.Length, target.Length)));

            comparisonResults.Add(Convert.ToDouble(LongestCommonSubstring.Calculate(source, target).Length) / Convert.ToDouble(Math.Min(source.Length, target.Length)));

            comparisonResults.Add(1 - SorensenDiceDistance.Calculate(source, target));

            comparisonResults.Add(OverlapCoefficient.Calculate(source, target));

            comparisonResults.Add(RatcliffObershelpSimilarity.Calculate(source, target));

            return comparisonResults.Max();
        }
    }
}
