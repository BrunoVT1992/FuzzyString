namespace FuzzyString.Algorithms
{
    public abstract class BaseAlgorithm
    {
        public virtual bool CanCalculate(string source, string target)
        {
            return true;
        }

        public abstract double Calculate(string source, string target);
    }
}
