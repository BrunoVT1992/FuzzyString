namespace FuzzyString.Algorithms
{
    //https://en.wikipedia.org/wiki/Hamming_distance
    public static class HammingDistance
    {
        public static int Calculate(string source, string target)
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
