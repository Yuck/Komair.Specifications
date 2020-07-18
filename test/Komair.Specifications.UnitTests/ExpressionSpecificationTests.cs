using NUnit.Framework;

namespace Komair.Specifications.UnitTests
{
    public class ExpressionSpecificationTests
    {
        [Test]
        public void ValidSpecification_IsTrue()
        {
            const string value = "short";

            var specification = new ExpressionSpecification<string>(t => t.Length < 10);
            var result = specification.IsSatisfiedBy(value);

            Assert.IsTrue(result);
        }

        [Test]
        public void ValidSpecification_WithValidAndLambda_IsTrue()
        {
            const string value = "short";

            var specification = new ExpressionSpecification<string>(t => t.Length < 10).And(t => t.StartsWith("s"));
            var result = specification.IsSatisfiedBy(value);

            Assert.IsTrue(result);
        }

        [Test]
        public void ValidSpecification_WithInvalidAndLambda_IsFalse()
        {
            const string value = "short";

            var specification = new ExpressionSpecification<string>(t => t.Length < 10).And(t => t.EndsWith("xxx"));
            var result = specification.IsSatisfiedBy(value);

            Assert.IsFalse(result);
        }

        [Test]
        public void ValidSpecification_WithValidOrLambda_IsTrue()
        {
            const string value = "short";

            var specification = new ExpressionSpecification<string>(t => t.Length < 10).Or(t => t.StartsWith("s"));
            var result = specification.IsSatisfiedBy(value);

            Assert.IsTrue(result);
        }

        [Test]
        public void ValidSpecification_WithInvalidOrLambda_IsTrue()
        {
            const string value = "short";

            var specification = new ExpressionSpecification<string>(t => t.Length < 10).Or(t => t.EndsWith("xxx"));
            var result = specification.IsSatisfiedBy(value);

            Assert.IsTrue(result);
        }

        [Test]
        public void InvalidSpecification_IsFalse()
        {
            const string value = "a long one";

            var specification = new ExpressionSpecification<string>(t => t.Length < 10);
            var result = specification.IsSatisfiedBy(value);

            Assert.IsFalse(result);
        }

        [Test]
        public void InvalidSpecification_WithValidAndLambda_IsFalse()
        {
            const string value = "a long one";

            var specification = new ExpressionSpecification<string>(t => t.Length < 10).And(t => t.StartsWith("s"));
            var result = specification.IsSatisfiedBy(value);

            Assert.IsFalse(result);
        }

        [Test]
        public void InvalidSpecification_WithInvalidAndLambda_IsFalse()
        {
            const string value = "a long one";

            var specification = new ExpressionSpecification<string>(t => t.Length < 10).And(t => t.EndsWith("xxx"));
            var result = specification.IsSatisfiedBy(value);

            Assert.IsFalse(result);
        }

        [Test]
        public void InvalidSpecification_WithValidOrLambda_IsTrue()
        {
            const string value = "a long one";

            var specification = new ExpressionSpecification<string>(t => t.Length < 10).Or(t => t.StartsWith("a"));
            var result = specification.IsSatisfiedBy(value);

            Assert.IsTrue(result);
        }

        [Test]
        public void InvalidSpecification_WithInvalidOrLambda_IsFalse()
        {
            const string value = "a long one";

            var specification = new ExpressionSpecification<string>(t => t.Length < 10).Or(t => t.EndsWith("xxx"));
            var result = specification.IsSatisfiedBy(value);

            Assert.IsFalse(result);
        }
    }
}