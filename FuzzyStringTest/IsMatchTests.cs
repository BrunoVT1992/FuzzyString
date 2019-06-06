using FuzzyString;
using NUnit.Framework;

namespace FuzzyStringTest
{
    public class IsMatchTests
    {
        [Test]
        public void SourceNull()
        {
            var isMatch = FuzzyStringFinder.Instance.IsMatch(null, "foo");

            Assert.IsFalse(isMatch);
        }

        [Test]
        public void SourceEmpty()
        {
            var isMatch = FuzzyStringFinder.Instance.IsMatch(string.Empty, "foo");

            Assert.IsFalse(isMatch);
        }

        [Test]
        public void TargetNull()
        {
            var isMatch = FuzzyStringFinder.Instance.IsMatch("foo", null);

            Assert.IsFalse(isMatch);
        }

        [Test]
        public void TargetEmpty()
        {
            var isMatch = FuzzyStringFinder.Instance.IsMatch("foo", string.Empty);

            Assert.IsFalse(isMatch);
        }

        [Test]
        public void SourceAndTargetNull()
        {
            var isMatch = FuzzyStringFinder.Instance.IsMatch(null, null);

            Assert.IsFalse(isMatch);
        }

        [Test]
        public void SourceAndTargetEmpty()
        {
            var isMatch = FuzzyStringFinder.Instance.IsMatch(string.Empty, string.Empty);

            Assert.IsFalse(isMatch);
        }

        [Test]
        public void ExactMatch_BothLowerCase_CaseSensitive()
        {
            var isMatch = FuzzyStringFinder.Instance.IsMatch("foo", "foo", true);

            Assert.IsTrue(isMatch);
        }

        [Test]
        public void ExactMatch_BothUpperCase_CaseSensitive()
        {
            var isMatch = FuzzyStringFinder.Instance.IsMatch("FOO", "FOO", true);

            Assert.IsTrue(isMatch);
        }

        [Test]
        public void ExactMatch_SourceUpperCase_CaseSensitive()
        {
            var isMatch = FuzzyStringFinder.Instance.IsMatch("FOO", "foo", true);

            Assert.IsFalse(isMatch);
        }

        [Test]
        public void ExactMatch_TargetUpperCase_CaseSensitive()
        {
            var isMatch = FuzzyStringFinder.Instance.IsMatch("foo", "FOO", true);

            Assert.IsFalse(isMatch);
        }

        [Test]
        public void ExactMatch_BothLowerCase_CaseInSensitive()
        {
            var isMatch = FuzzyStringFinder.Instance.IsMatch("foo", "foo", false);

            Assert.IsTrue(isMatch);
        }

        [Test]
        public void ExactMatch_BothUpperCase_CaseInSensitive()
        {
            var isMatch = FuzzyStringFinder.Instance.IsMatch("FOO", "FOO", false);

            Assert.IsTrue(isMatch);
        }

        [Test]
        public void ExactMatch_SourceUpperCase_CaseInSensitive()
        {
            var isMatch = FuzzyStringFinder.Instance.IsMatch("FOO", "foo", false);

            Assert.IsTrue(isMatch);
        }

        [Test]
        public void ExactMatch_TargetUpperCase_CaseInSensitive()
        {
            var isMatch = FuzzyStringFinder.Instance.IsMatch("foo", "FOO", false);

            Assert.IsTrue(isMatch);
        }

        [Test]
        public void ExactMatch_SourceMixedCase_CaseSensitive()
        {
            var isMatch = FuzzyStringFinder.Instance.IsMatch("HELLO world", "hello world", true);

            Assert.IsFalse(isMatch);
        }

        [Test]
        public void ExactMatch_TargetMixedCase_CaseSensitive()
        {
            var isMatch = FuzzyStringFinder.Instance.IsMatch("hello world", "HELLO world", true);

            Assert.IsFalse(isMatch);
        }

        [Test]
        public void WrongSpelling_CaseSensitive()
        {
            var isMatch = FuzzyStringFinder.Instance.IsMatch("hello", "world", true);

            Assert.IsFalse(isMatch);
        }

        [Test]
        public void WrongSpelling_CaseInsensitive()
        {
            var isMatch = FuzzyStringFinder.Instance.IsMatch("hello", "world", false);

            Assert.IsFalse(isMatch);
        }

        [Test]
        public void PartialWrongSpelling_CaseSensitive()
        {
            var isMatch = FuzzyStringFinder.Instance.IsMatch("Hello World", "hello world", true);

            Assert.IsTrue(isMatch);
        }

        [Test]
        public void PartialWrongSpelling_CaseInsensitive()
        {
            var isMatch = FuzzyStringFinder.Instance.IsMatch("hello orld", "hello world", false);

            Assert.IsTrue(isMatch);
        }

        [Test]
        public void PartialWrongSpelling_LowRequiredMatchStrenght_HighMatchCount()
        {
            var isMatch = FuzzyStringFinder.Instance.IsMatch("hell Worl", "hello world", false, 0.5, 6);

            Assert.IsTrue(isMatch);
        }

        [Test]
        public void PartialWrongSpelling_HighRequiredMatchStrenght_HighMatchCount()
        {
            var isMatch = FuzzyStringFinder.Instance.IsMatch("hell Worl", "hello world", false, 0.85, 6);

            Assert.IsFalse(isMatch);
        }

        [Test]
        public void PartialWrongSpelling_LowMatchCount()
        {
            var isMatch = FuzzyStringFinder.Instance.IsMatch("hell Worl", "hello world", false, minMatchCount: 1);

            Assert.IsTrue(isMatch);
        }
    }
}