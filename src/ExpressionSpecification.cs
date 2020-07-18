using System;
using System.Linq.Expressions;
using Komair.Specifications.Abstract;

namespace Komair.Specifications
{
    public class ExpressionSpecification<T> : SpecificationBase<T>
    {
        private readonly Expression<Func<T, bool>> _expression;

        public ExpressionSpecification(Expression<Func<T, bool>> expression)
        {
            _expression = expression ?? throw new ArgumentNullException(nameof(expression));
        }

        public ExpressionSpecification<T> And(Expression<Func<T, bool>> expression)
        {
            var left = _expression;
            var right = expression;
            var parameters = Expression.Parameter(typeof(T));
            var body = new ParameterReplacer(parameters).Visit(Expression.AndAlso(left.Body, right.Body));
            // TODO: Need unit test coverage for this condition
            if (body == null)
                throw new InvalidOperationException();

            return new ExpressionSpecification<T>(Expression.Lambda<Func<T, bool>>(body, parameters));
        }

        public override bool IsSatisfiedBy(T t)
        {
            return _expression.Compile()(t);
        }

        public ExpressionSpecification<T> Or(Expression<Func<T, bool>> expression)
        {
            var left = _expression;
            var right = expression;
            var parameters = Expression.Parameter(typeof(T));
            var body = new ParameterReplacer(parameters).Visit(Expression.OrElse(left.Body, right.Body));
            // TODO: Need unit test coverage for this condition
            if (body == null)
                throw new InvalidOperationException();

            return new ExpressionSpecification<T>(Expression.Lambda<Func<T, bool>>(body, parameters));
        }

        internal class ParameterReplacer : ExpressionVisitor
        {
            private readonly ParameterExpression _parameter;

            internal ParameterReplacer(ParameterExpression parameter)
            {
                _parameter = parameter;
            }

            protected override Expression VisitParameter(ParameterExpression parameter)
            {
                return base.VisitParameter(_parameter);
            }
        }
    }
}