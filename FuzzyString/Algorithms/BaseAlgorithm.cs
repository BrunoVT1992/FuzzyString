namespace FuzzyString.Algorithms
{
    public abstract class BaseAlgorithm
    {
        public virtual bool CanCalculate(string source, string target)
        {
            return true;
        }

        /// <summary>
        /// Returns a value between 0.0 and 1.0. 
        /// The higher the value, the better the match
        /// </summary>
        public abstract double Calculate(string source, string target);
    }
}
