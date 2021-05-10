using System;
using System.Linq.Expressions;
using Komair.Specifications.Internal.ExpressionTrees;

namespace Komair.Specifications.Extensions
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<T, Boolean>> Simplify<T>(this Expression expression)
        {
            if (expression == null)
                return null;

            var parameters = Expression.Parameter(typeof(T));
            var body = new ParameterReplacer(parameters).Visit(expression) ?? expression;
            var simplified = body is Expression<Func<T, Boolean>> lambda ? lambda : Expression.Lambda<Func<T, Boolean>>(body, parameters);

            return simplified;
        }
    }
}