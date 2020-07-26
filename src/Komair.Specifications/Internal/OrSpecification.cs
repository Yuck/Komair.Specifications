using System;
using System.Linq.Expressions;
using Komair.Specifications.Abstract;

namespace Komair.Specifications.Internal
{
    internal class OrSpecification<T> : SpecificationBase<T>
    {
        private readonly ISpecification<T> _left;
        private readonly ISpecification<T> _right;

        public OrSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            _left = left ?? throw new ArgumentNullException(nameof(left));
            _right = right ?? throw new ArgumentNullException(nameof(right));
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            var left = _left.ToExpression();
            var right = _right.ToExpression();
            var parameters = Expression.Parameter(typeof(T));
            var body = new ParameterReplacer(parameters).Visit(Expression.OrElse(left.Body, right.Body));
            // TODO: Need unit test coverage for this condition
            if (body == null)
                throw new InvalidOperationException();

            return new ExpressionSpecification<T>(Expression.Lambda<Func<T, bool>>(body, parameters));
        }
    }
}