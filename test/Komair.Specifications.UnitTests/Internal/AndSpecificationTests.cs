using NUnit.Framework;

namespace Komair.Specifications.UnitTests.Internal
{
    public class AndSpecificationTests
    {
        [Test]
        public void LeftIsTrue_And_RightIsTrue_IsTrue()
        {
            const string value = "short";

            var left = new ShortStringSpecification();
            var right = new HasOrtSpecification();
            var specification = left.And(right);
            var result = specification.IsSatisfiedBy(value);

            Assert.IsTrue(result);
        }

        [Test]
        public void LeftIsTrue_And_RightIsFalse_IsFalse()
        {
            const string value = "short";

            var left = new ShortStringSpecification();
            var right = new HasLongSpecification();
            var specification = left.And(right);
            var result = specification.IsSatisfiedBy(value);

            Assert.IsFalse(result);
        }

        [Test]
        public void LeftIsFalse_And_RightIsTrue_IsFalse()
        {
            const string value = "a long one";

            var left = new ShortStringSpecification();
            var right = new HasLongSpecification();
            var specification = left.And(right);
            var result = specification.IsSatisfiedBy(value);

            Assert.IsFalse(result);
        }
    }
}