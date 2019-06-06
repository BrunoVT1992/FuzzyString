using System;
using System.Linq;

namespace FuzzyString.Algorithms
{
    //https://en.wikipedia.org/wiki/Sørensen–Dice_coefficient
    public static class SorensenDiceDistance
    {
        public static double Calculate(string source, string target)
        {
            return 1 - CalculateIndex(source, target);
        }

        public static double CalculateIndex(string source, string target)
        {
            return (2 * Convert.ToDouble(source.Intersect(target).Count())) / (Convert.ToDouble(source.Length + target.Length));
        }
    }
}
