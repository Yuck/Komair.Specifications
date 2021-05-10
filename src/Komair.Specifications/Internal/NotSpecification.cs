using System;
using System.Linq.Expressions;
using Komair.Specifications.Abstract;
using Komair.Specifications.Extensions;

namespace Komair.Specifications.Internal
{
    internal class NotSpecification<T> : SpecificationBase<T>
    {
        private readonly ISpecification<T> _specification;

        public NotSpecification(ISpecification<T> specification)
        {
            _specification = specification;
        }

        public override Expression<Func<T, Boolean>> ToExpression() => Expression.Not(_specification.ToExpression().Body).Simplify<T>();
    }
}