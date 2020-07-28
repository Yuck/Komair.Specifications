using System;
using System.Linq.Expressions;
using Komair.Specifications.Abstract;

namespace Komair.Specifications
{
    public class TrueSpecification<T> : SpecificationBase<T>
    {
        public override Expression<Func<T, bool>> ToExpression()
        {
            return Expression.Lambda<Func<T, bool>>(Expression.Constant(true));
        }
    }
}