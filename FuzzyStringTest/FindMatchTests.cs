using FuzzyString;
using NUnit.Framework;
using System.Collections.Generic;

namespace FuzzyStringTest
{
    public class FindMatchTests
    {
        [Test]
        public void TargetsNull()
        {
            var match = FuzzyStringFinder.Instance.FindMatch("foo", null);

            Assert.IsNull(match);
        }

        [Test]
        public void TargetsEmpty()
        {
            var targets = new List<string>();

            var match = FuzzyStringFinder.Instance.FindMatch("foo", targets);

            Assert.IsNull(match);
        }

        [Test]
        public void SourceNull()
        {
            var targets = new List<string>
            {
                "foo"
            };

            var match = FuzzyStringFinder.Instance.FindMatch(null, targets);

            Assert.IsNull(match);
        }

        [Test]
        public void SourceEmpty()
        {
            var targets = new List<string>
            {
                "foo"
            };

            var match = FuzzyStringFinder.Instance.FindMatch(string.Empty, targets);

            Assert.IsNull(match);
        }

        [Test]
        public void SourceAndTargetEmptyNull()
        {
            var match = FuzzyStringFinder.Instance.FindMatch(null, null);

            Assert.IsNull(match);
        }

        [Test]
        public void SourceAndTargetEmpty()
        {
            var targets = new List<string>();

            var match = FuzzyStringFinder.Instance.FindMatch(string.Empty, targets);

            Assert.IsNull(match);
        }

        [Test]
        public void SourceExactMatch_CaseSensitive()
        {
            var targets = new List<string>
            {
                "foo",
                "hello world",
                "FOO",
                "HELLO WORLD"
            };

            var match = FuzzyStringFinder.Instance.FindMatch("foo", targets, true);

            Assert.IsNotNull(match);
            Assert.AreEqual("foo", match);
        }

        [Test]
        public void SourceExactMatch_CaseSensitive_LowerCaseMatch()
        {
            var targets = new List<string>
            {
                "foo",
                "hello world",
                "FOO",
                "HELLO WORLD"
            };

            var match = FuzzyStringFinder.Instance.FindMatch("Foo", targets, true);

            Assert.IsNotNull(match);
            Assert.AreEqual("foo", match);
        }

        [Test]
        public void SourceExactMatch_CaseSensitive_UpperCaseMatch()
        {
            var targets = new List<string>
            {
                "foo",
                "hello world",
                "FOO",
                "HELLO WORLD"
            };

            var match = FuzzyStringFinder.Instance.FindMatch("FoO", targets, true);

            Assert.IsNotNull(match);
            Assert.AreEqual("FOO", match);
        }

        [Test]
        public void SourceExactMatch_CaseInSensitive_LowerCaseMatch()
        {
            var targets = new List<string>
            {
                "foo",
                "hello world"
            };

            var match = FuzzyStringFinder.Instance.FindMatch("foo", targets, false);

            Assert.IsNotNull(match);
            Assert.AreEqual("foo", match);
        }

        [Test]
        public void SourceExactMatch_CaseInSensitive_UpperCaseMatch()
        {
            var targets = new List<string>
            {
                "foo",
                "hello world"
            };

            var match = FuzzyStringFinder.Instance.FindMatch("FOO", targets, false);

            Assert.IsNotNull(match);
            Assert.AreEqual("foo", match);
        }

        [Test]
        public void SourcePartialMatch_CaseSensitive_LowerCaseMatch()
        {
            var targets = new List<string>
            {
                "foo",
                "hello world",
                "FOO",
                "HELLO WORLD"
            };

            var match = FuzzyStringFinder.Instance.FindMatch("hello orld", targets, true);

            Assert.IsNotNull(match);
            Assert.AreEqual("hello world", match);
        }

        [Test]
        public void SourcePartialMatch_CaseSensitive_UpperCaseMatch()
        {
            var targets = new List<string>
            {
                "foo",
                "hello world",
                "FOO",
                "HELLO WORLD"
            };

            var match = FuzzyStringFinder.Instance.FindMatch("HELLO ORLD", targets, true);

            Assert.IsNotNull(match);
            Assert.AreEqual("HELLO WORLD", match);
        }

        [Test]
        public void SourcePartialMatch_CaseInSensitive()
        {
            var targets = new List<string>
            {
                "foo",
                "hello world"
            };

            var match = FuzzyStringFinder.Instance.FindMatch("HeLLo ORlD", targets, false);

            Assert.IsNotNull(match);
            Assert.AreEqual("hello world", match);
        }

        [Test]
        public void SourceNoMatch_CaseSensitive()
        {
            var targets = new List<string>
            {
                "foo",
                "hello world"
            };

            var match = FuzzyStringFinder.Instance.FindMatch("abcde", targets, true);

            Assert.IsNull(match);
        }

        [Test]
        public void SourceNoMatch_CaseInSensitive()
        {
            var targets = new List<string>
            {
                "foo",
                "hello world"
            };

            var match = FuzzyStringFinder.Instance.FindMatch("aBcDe", targets, false);

            Assert.IsNull(match);
        }

        [Test]
        public void SourcePartialMatch_HighRequiredMatchStrenght_HighMatchCount()
        {
            var targets = new List<string>
            {
                "foo",
                "hello world"
            };

            var match = FuzzyStringFinder.Instance.FindMatch("hell worl", targets, false, 0.85, 6);

            Assert.IsNull(match);
        }

        [Test]
        public void SourcePartialMatch_LowRequiredMatchStrenght_HighMatchCount()
        {
            var targets = new List<string>
            {
                "foo",
                "hello world"
            };

            var match = FuzzyStringFinder.Instance.FindMatch("hell worl", targets, false, 0.5, 6);

            Assert.IsNotNull(match);
            Assert.AreEqual("hello world", match);
        }

        [Test]
        public void SourcePartialMatch_MaxRequiredMatchStrenght()
        {
            var targets = new List<string>
            {
                "foo",
                "hello world"
            };

            var match = FuzzyStringFinder.Instance.FindMatch("hell world", targets, false, 1.0);

            Assert.IsNull(match);
        }

        [Test]
        public void SourcePartialMatch_MinRequiredMatchStrenght()
        {
            var targets = new List<string>
            {
                "foo"
            };

            var match = FuzzyStringFinder.Instance.FindMatch("abc", targets, false, 0.0);

            Assert.IsNotNull(match);
            Assert.AreEqual("foo", match);
        }
    }
}
