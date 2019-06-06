namespace FuzzyString.Algorithms
{
    /// <summary>
    /// https://en.wikipedia.org/wiki/Hamming_distance
    /// </summary>
    public class HammingDistance : BaseAlgorithm
    {
        public override double Calculate(string source, string target)
        {
            return 1 - (CalculateHammingDistance(source, target) / (double)target.Length);
        }

        public override bool CanCalculate(string source, string target)
        {
            return source.Length == target.Length;
        }

        private int CalculateHammingDistance(string source, string target)
        {
            if (source.Length != target.Length)
                return int.MaxValue;

            var distance = 0;

            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] != target[i])
                    distance++;
            }

            return distance;
        }
    }
}
