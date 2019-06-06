using FuzzyString.Algorithms;
using System.Collections.Generic;
using System.Linq;

namespace FuzzyString
{
    public class FuzzyStringFinder
    {
        private List<BaseAlgorithm> _algorithms;

        public FuzzyStringFinder()
        {
            _algorithms = new List<BaseAlgorithm>
            {
                new HammingDistance(),
                new JaccardDistance(),
                new LevenshteinDistance(),
                new LongestCommonSubsequence(),
                new LongestCommonSubstring(),
                new OverlapCoefficient(),
                new RatcliffObershelpSimilarity(),
                new SorensenDiceDistance()
            };
        }

        public string FindMatch(string source, IEnumerable<string> targets, bool caseSensitive = true, double requiredMatchStrenght = 0.66, int minMatchCount = 3)
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

        public bool IsMatch(string source, string target, bool caseSensitive = true, double requiredMatchStrenght = 0.66, int minMatchCount = 2)
        {
            var foundMatchStrenghts = FindMatchStrenght(source, target, caseSensitive);

            var passingMatchStrenghts = foundMatchStrenghts.Where(x => x >= requiredMatchStrenght);

            return passingMatchStrenghts.Count() >= minMatchCount && passingMatchStrenghts.Max() >= requiredMatchStrenght;
        }

        private List<double> FindMatchStrenght(string source, string target, bool caseSensitive)
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

            foreach (var algorithm in _algorithms)
            {
                if (algorithm.CanCalculate(source, target))
                    comparisonResults.Add(algorithm.Calculate(source, target));
            }

            return comparisonResults;
        }

        public void AddAlgorithm(BaseAlgorithm algorithm)
        {
            _algorithms.Add(algorithm);
        }

        private static object _locker = new object();
        private static FuzzyStringFinder _instance;
        public static FuzzyStringFinder Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_locker)
                    {
                        if (_instance == null)
                            _instance = new FuzzyStringFinder();
                    }
                }

                return _instance;
            }
        }
    }
}
