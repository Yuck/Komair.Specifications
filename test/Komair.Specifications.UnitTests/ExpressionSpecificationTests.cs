using System;
using System.Linq.Expressions;
using Komair.Specifications.Abstract;
using NUnit.Framework;

namespace Komair.Specifications.UnitTests
{
    // TODO: Need a better, shared place for these specifications
    public class ShortStringSpecification : SpecificationBase<string>
    {
        public override Expression<Func<string, bool>> ToExpression()
        {
            return t => t.Length < 10;
        }
    }

    public class HasPrefixSpecification : SpecificationBase<string>
    {
        private readonly string _prefix;

        public HasPrefixSpecification(string prefix)
        {
            _prefix = prefix;
        }

        public override Expression<Func<string, bool>> ToExpression()
        {
            return t => t.StartsWith(_prefix);
        }
    }

    public class HasSuffixSpecification : SpecificationBase<string>
    {
        private readonly string _suffix;

        public HasSuffixSpecification(string suffix)
        {
            _suffix = suffix;
        }

        public override Expression<Func<string, bool>> ToExpression()
        {
            return t => t.EndsWith(_suffix);
        }
    }

    public class HasOrtSpecification : SpecificationBase<string>
    {
        public override Expression<Func<string, bool>> ToExpression()
        {
            return t => t.Contains("ort");
        }
    }

    public class HasLongSpecification : SpecificationBase<string>
    {
        public override Expression<Func<string, bool>> ToExpression()
        {
            return t => t.Contains("long");
        }
    }

    public class ExpressionSpecificationTests
    {
        [Test]
        public void ValidSpecification_IsTrue()
        {
            const string value = "short";

            var specification = new ShortStringSpecification();
            var result = specification.IsSatisfiedBy(value);

            Assert.IsTrue(result);
        }

        [Test]
        public void ValidSpecification_WithValidAndLambda_IsTrue()
        {
            const string value = "short";

            var specification = new ShortStringSpecification().And(new HasPrefixSpecification("s"));
            var result = specification.IsSatisfiedBy(value);

            Assert.IsTrue(result);
        }

        [Test]
        public void ValidSpecification_WithInvalidAndLambda_IsFalse()
        {
            const string value = "short";

            var specification = new ShortStringSpecification().And(new HasSuffixSpecification("xxx"));
            var result = specification.IsSatisfiedBy(value);

            Assert.IsFalse(result);
        }

        [Test]
        public void ValidSpecification_WithValidOrLambda_IsTrue()
        {
            const string value = "short";

            var specification = new ShortStringSpecification().Or(new HasPrefixSpecification("s"));
            var result = specification.IsSatisfiedBy(value);

            Assert.IsTrue(result);
        }

        [Test]
        public void ValidSpecification_WithInvalidOrLambda_IsTrue()
        {
            const string value = "short";

            var specification = new ShortStringSpecification().Or(new HasSuffixSpecification("xxx"));
            var result = specification.IsSatisfiedBy(value);

            Assert.IsTrue(result);
        }

        [Test]
        public void InvalidSpecification_IsFalse()
        {
            const string value = "a long one";

            var specification = new ShortStringSpecification();
            var result = specification.IsSatisfiedBy(value);

            Assert.IsFalse(result);
        }

        [Test]
        public void InvalidSpecification_WithValidAndLambda_IsFalse()
        {
            const string value = "a long one";

            var specification = new ShortStringSpecification().And(new HasPrefixSpecification("s"));
            var result = specification.IsSatisfiedBy(value);

            Assert.IsFalse(result);
        }

        [Test]
        public void InvalidSpecification_WithInvalidAndLambda_IsFalse()
        {
            const string value = "a long one";

            var specification = new ShortStringSpecification().And(new HasSuffixSpecification("xxx"));
            var result = specification.IsSatisfiedBy(value);

            Assert.IsFalse(result);
        }

        [Test]
        public void InvalidSpecification_WithValidOrLambda_IsTrue()
        {
            const string value = "a long one";

            var specification = new ShortStringSpecification().Or(new HasPrefixSpecification("a"));
            var result = specification.IsSatisfiedBy(value);

            Assert.IsTrue(result);
        }

        [Test]
        public void InvalidSpecification_WithInvalidOrLambda_IsFalse()
        {
            const string value = "a long one";

            var specification = new ShortStringSpecification().Or(new HasSuffixSpecification("xxx"));
            var result = specification.IsSatisfiedBy(value);

            Assert.IsFalse(result);
        }
    }
}