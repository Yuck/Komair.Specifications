using System;
using System.Linq.Expressions;
using Komair.Specifications.Abstract;
using Komair.Specifications.Extensions;

namespace Komair.Specifications.Internal
{
    public abstract class BinarySpecificationBase<T> : SpecificationBase<T>
    {
        protected ISpecification<T> Left;
        protected ISpecification<T> Right;

        protected BinarySpecificationBase(ISpecification<T> left, ISpecification<T> right)
        {
            Left = left ?? throw new ArgumentNullException(nameof(left));
            Right = right ?? throw new ArgumentNullException(nameof(right));
        }

        public override Expression<Func<T, bool>> ToExpression() => GetBinaryExpression().Simplify<T>();

        protected abstract BinaryExpression GetBinaryExpression();
    }
}