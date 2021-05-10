using System;
using System.Linq.Expressions;
using Komair.Specifications.Abstract;

namespace Komair.Specifications.Internal
{
    internal class OrSpecification<T> : BinarySpecificationBase<T>
    {
        public OrSpecification(ISpecification<T> left, ISpecification<T> right) : base(left, right)
        {
        }

        protected override BinaryExpression GetBinaryExpression() => Expression.OrElse(Left.ToExpression().Body, Right.ToExpression().Body);
    }
}