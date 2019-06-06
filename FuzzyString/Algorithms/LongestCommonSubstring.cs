using System;
using System.Text;

namespace FuzzyString.Algorithms
{
    /// <summary>
    /// https://en.wikipedia.org/wiki/Longest_common_substring_problem
    /// </summary>
    public class LongestCommonSubstring : BaseAlgorithm
    {
        public override double Calculate(string source, string target)
        {
            return Convert.ToDouble(CalculateLongestCommonSubstring(source, target).Length) / Convert.ToDouble(Math.Min(source.Length, target.Length));
        }

        private string CalculateLongestCommonSubstring(string source, string target)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(target))
                return null;

            int[,] L = new int[source.Length, target.Length];

            var maximumLength = 0;
            var lastSubsBegin = 0;

            var stringBuilder = new StringBuilder();

            for (int i = 0; i < source.Length; i++)
            {
                for (int j = 0; j < target.Length; j++)
                {
                    if (source[i] != target[j])
                        L[i, j] = 0;
                    else
                    {
                        if ((i == 0) || (j == 0))
                            L[i, j] = 1;
                        else
                            L[i, j] = 1 + L[i - 1, j - 1];

                        if (L[i, j] > maximumLength)
                        {
                            maximumLength = L[i, j];

                            var thisSubsBegin = i - L[i, j] + 1;

                            if (lastSubsBegin == thisSubsBegin)
                                stringBuilder.Append(source[i]);
                            else
                            {
                                lastSubsBegin = thisSubsBegin;

                                stringBuilder.Length = 0;

                                stringBuilder.Append(source.Substring(lastSubsBegin, (i + 1) - lastSubsBegin));
                            }
                        }
                    }
                }
            }

            return stringBuilder.ToString();
        }
    }
}
