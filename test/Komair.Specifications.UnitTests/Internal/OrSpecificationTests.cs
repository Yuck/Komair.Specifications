using NUnit.Framework;

namespace Komair.Specifications.UnitTests.Internal
{
    public class OrSpecificationTests
    {
        [Test]
        public void LeftIsTrue_And_RightIsTrue_IsTrue()
        {
            const string value = "short";

            var left = new ExpressionSpecification<string>(t => t.Length < 10);
            var right = new ExpressionSpecification<string>(t => t.Contains("ho"));
            var specification = left.Or(right);
            var result = specification.IsSatisfiedBy(value);

            Assert.IsTrue(result);
        }

        [Test]
        public void LeftIsTrue_And_RightIsFalse_IsTrue()
        {
            const string value = "short";

            var left = new ExpressionSpecification<string>(t => t.Length < 10);
            var right = new ExpressionSpecification<string>(t => t.Contains("long"));
            var specification = left.Or(right);
            var result = specification.IsSatisfiedBy(value);

            Assert.IsTrue(result);
        }

        [Test]
        public void LeftIsFalse_And_RightIsTrue_IsTrue()
        {
            const string value = "a long one";

            var left = new ExpressionSpecification<string>(t => t.Length < 10);
            var right = new ExpressionSpecification<string>(t => t.Contains("long"));
            var specification = left.Or(right);
            var result = specification.IsSatisfiedBy(value);

            Assert.IsTrue(result);
        }

        [Test]
        public void LeftIsFalse_And_RightIsFalse_IsFalse()
        {
            const string value = "a long one";

            var left = new ExpressionSpecification<string>(t => t.Length < 10);
            var right = new ExpressionSpecification<string>(t => t.Contains("ho"));
            var specification = left.Or(right);
            var result = specification.IsSatisfiedBy(value);

            Assert.IsFalse(result);
        }
    }
}