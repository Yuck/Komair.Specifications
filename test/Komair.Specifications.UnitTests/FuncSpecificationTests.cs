using NUnit.Framework;

namespace Komair.Specifications.UnitTests
{
    public class FuncSpecificationTests
    {
        [Test]
        public void ValidSpecification_IsTrue()
        {
            const string value = "short";

            var specification = new FuncSpecification<string>(t => t.Length < 10);
            var result = specification.IsSatisfiedBy(value);

            Assert.IsTrue(result);
        }

        [Test]
        public void InvalidSpecification_IsFalse()
        {
            const string value = "a long one";

            var specification = new FuncSpecification<string>(t => t.Length < 10);
            var result = specification.IsSatisfiedBy(value);

            Assert.IsFalse(result);
        }
    }
}