using System;
using System.Linq.Expressions;
using Komair.Specifications.Internal.ExpressionTrees;

namespace Komair.Specifications.Extensions
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<T, bool>> Simplify<T>(this Expression expression)
        {
            if (expression == null)
                return null;

            var parameters = Expression.Parameter(typeof(T));
            var body = new ParameterReplacer(parameters).Visit(expression);
            var simplified = body is Expression<Func<T, bool>> lambda ? lambda : Expression.Lambda<Func<T, bool>>(body, parameters);

            return simplified;
        }
    }
}