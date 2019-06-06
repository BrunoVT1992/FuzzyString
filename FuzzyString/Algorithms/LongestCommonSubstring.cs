using System.Text;

namespace FuzzyString.Algorithms
{
    //https://en.wikipedia.org/wiki/Longest_common_substring_problem
    public static class LongestCommonSubstring
    {
        /// <summary>
        /// Gives back the longes common subsequence
        /// For example: in source 123456 and target 003400 it will give back 34
        /// </summary>
        public static string Calculate(string source, string target)
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
