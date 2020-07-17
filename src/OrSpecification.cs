using System;
using Komair.Specifications.Abstract;

namespace Komair.Specifications
{
    public class OrSpecification<T> : SpecificationBase<T>
    {
        private readonly ISpecification<T> _left;
        private readonly ISpecification<T> _right;

        public OrSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            _left = left ?? throw new ArgumentNullException(nameof(left));
            _right = right ?? throw new ArgumentNullException(nameof(right));
        }

        public override bool IsSatisfiedBy(T t)
        {
            return _left.IsSatisfiedBy(t) || _right.IsSatisfiedBy(t);
        }
    }
}