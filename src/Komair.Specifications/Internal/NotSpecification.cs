using Komair.Specifications.Abstract;

namespace Komair.Specifications.Internal
{
    internal class NotSpecification<T> : SpecificationBase<T>
    {
        private readonly ISpecification<T> _specification;

        public NotSpecification(ISpecification<T> specification)
        {
            _specification = specification;
        }

        public override bool IsSatisfiedBy(T t)
        {
            return ! _specification.IsSatisfiedBy(t);
        }
    }
}