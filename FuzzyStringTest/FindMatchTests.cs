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
            var match = FuzzyStringFinder.FindMatch("foo", null);

            Assert.IsNull(match);
        }

        [Test]
        public void TargetsEmpty()
        {
            var targets = new List<string>();

            var match = FuzzyStringFinder.FindMatch("foo", targets);

            Assert.IsNull(match);
        }

        [Test]
        public void SourceNull()
        {
            var targets = new List<string>
            {
                "foo"
            };

            var match = FuzzyStringFinder.FindMatch(null, targets);

            Assert.IsNull(match);
        }

        [Test]
        public void SourceEmpty()
        {
            var targets = new List<string>
            {
                "foo"
            };

            var match = FuzzyStringFinder.FindMatch(string.Empty, targets);

            Assert.IsNull(match);
        }

        [Test]
        public void SourceAndTargetEmptyNull()
        {
            var match = FuzzyStringFinder.FindMatch(null, null);

            Assert.IsNull(match);
        }

        [Test]
        public void SourceAndTargetEmpty()
        {
            var targets = new List<string>();

            var match = FuzzyStringFinder.FindMatch(string.Empty, targets);

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

            var match = FuzzyStringFinder.FindMatch("foo", targets, true);

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

            var match = FuzzyStringFinder.FindMatch("Foo", targets, true);

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

            var match = FuzzyStringFinder.FindMatch("FoO", targets, true);

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

            var match = FuzzyStringFinder.FindMatch("foo", targets, false);

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

            var match = FuzzyStringFinder.FindMatch("FOO", targets, false);

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

            var match = FuzzyStringFinder.FindMatch("hello orld", targets, true);

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

            var match = FuzzyStringFinder.FindMatch("HELLO ORLD", targets, true);

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

            var match = FuzzyStringFinder.FindMatch("HeLLo ORlD", targets, false);

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

            var match = FuzzyStringFinder.FindMatch("abcde", targets, true);

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

            var match = FuzzyStringFinder.FindMatch("aBcDe", targets, false);

            Assert.IsNull(match);
        }
    }
}
