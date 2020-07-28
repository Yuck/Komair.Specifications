using System;
using System.Linq.Expressions;
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

        public override Expression<Func<T, bool>> ToExpression()
        {
            var expression = _specification.ToExpression();
            var parameters = expression.Parameters;
            var body = Expression.Not(expression.Body);
            // TODO: Need unit test coverage for this condition
            if (body == null)
                throw new InvalidOperationException();

            return new ExpressionSpecification<T>(Expression.Lambda<Func<T, bool>>(body, parameters));
        }
    }
}