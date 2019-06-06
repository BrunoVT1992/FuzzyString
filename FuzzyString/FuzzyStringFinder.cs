using FuzzyString.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FuzzyString
{
    public static class FuzzyStringFinder
    {
        public static string FindMatch(string source, IEnumerable<string> targets, bool caseSensitive = true, double requiredMatchStrenght = 0.66, int minMatchCount = 3)
        {
            if (targets?.Any() != true)
                return null;

            string foundMatch = null;
            var foundMatchStrenght = -1.0;

            foreach (var target in targets)
            {
                var currentMatchStrenghts = FindMatchStrenght(source, target, caseSensitive);

                var passingMatchStrenghts = currentMatchStrenghts.Where(x => x >= requiredMatchStrenght);

                if (passingMatchStrenghts.Count() >= minMatchCount)
                {
                    var maxPassingMaxStrenght = passingMatchStrenghts.Max();

                    if (maxPassingMaxStrenght >= requiredMatchStrenght && maxPassingMaxStrenght > foundMatchStrenght)
                    {
                        foundMatchStrenght = maxPassingMaxStrenght;
                        foundMatch = target;
                    }
                }
            }

            return foundMatch;
        }

        public static bool IsMatch(string source, string target, bool caseSensitive = true, double requiredMatchStrenght = 0.66, int minMatchCount = 2)
        {
            var foundMatchStrenghts = FindMatchStrenght(source, target, caseSensitive);

            var passingMatchStrenghts = foundMatchStrenghts.Where(x => x >= requiredMatchStrenght);

            return passingMatchStrenghts.Count() >= minMatchCount && passingMatchStrenghts.Max() >= requiredMatchStrenght;
        }

        private static List<double> FindMatchStrenght(string source, string target, bool caseSensitive)
        {
            var comparisonResults = new List<double>();

            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(target))
                return comparisonResults;

            if (!caseSensitive)
            {
                source = source?.ToLower();
                target = target?.ToLower();
            }

            if (source == target)
                comparisonResults.Add(1);

            if (source.Length == target.Length)
                comparisonResults.Add(1 - (HammingDistance.Calculate(source, target) / (double)target.Length));

            comparisonResults.Add(1 - JaccardDistance.Calculate(source, target));

            comparisonResults.Add(1 - Convert.ToDouble(LevenshteinDistance.Calculate(source, target)) / Convert.ToDouble(LevenshteinDistance.CalculateUpperBounds(source, target)));

            comparisonResults.Add(Convert.ToDouble(LongestCommonSubsequence.Calculate(source, target).Length) / Convert.ToDouble(Math.Min(source.Length, target.Length)));

            comparisonResults.Add(Convert.ToDouble(LongestCommonSubstring.Calculate(source, target).Length) / Convert.ToDouble(Math.Min(source.Length, target.Length)));

            comparisonResults.Add(1 - SorensenDiceDistance.Calculate(source, target));

            comparisonResults.Add(OverlapCoefficient.Calculate(source, target));

            comparisonResults.Add(RatcliffObershelpSimilarity.Calculate(source, target));

            return comparisonResults;
        }
    }
}
