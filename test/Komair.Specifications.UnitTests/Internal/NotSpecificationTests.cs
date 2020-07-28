using NUnit.Framework;

namespace Komair.Specifications.UnitTests.Internal
{
    public class NotSpecificationTests
    {
        [Test]
        public void ValidSpecification_WhenNegated_IsFalse()
        {
            const string value = "short";

            var specification = new ShortStringSpecification();
            var result = specification.Not().IsSatisfiedBy(value);

            Assert.IsFalse(result);
        }

        [Test]
        public void InvalidSpecification_WhenNegated_IsTrue()
        {
            const string value = "a long one";

            var specification = new ShortStringSpecification();
            var result = specification.Not().IsSatisfiedBy(value);

            Assert.IsTrue(result);
        }
    }
}