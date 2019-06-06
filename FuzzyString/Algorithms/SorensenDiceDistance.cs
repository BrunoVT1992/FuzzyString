using System;
using System.Linq;

namespace FuzzyString.Algorithms
{
    /// <summary>
    /// https://en.wikipedia.org/wiki/Sørensen–Dice_coefficient
    /// </summary>
    public class SorensenDiceDistance : BaseAlgorithm
    {
        public override double Calculate(string source, string target)
        {
            return CalculateSorensenDiceDistance(source, target);
        }

        private double CalculateSorensenDiceDistance(string source, string target)
        {
            return (2 * Convert.ToDouble(source.Intersect(target).Count())) / (Convert.ToDouble(source.Length + target.Length));
        }
    }
}
