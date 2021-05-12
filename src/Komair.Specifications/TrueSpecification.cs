using System;
using System.Linq.Expressions;
using Komair.Specifications.Abstract;
using Komair.Specifications.Extensions;

namespace Komair.Specifications
{
    public class TrueSpecification<T> : SpecificationBase<T>
    {
        private static readonly Lazy<TrueSpecification<T>> IdentityInstance = new Lazy<TrueSpecification<T>>(() => new TrueSpecification<T>());

        public static TrueSpecification<T> Identity => IdentityInstance.Value;

        private TrueSpecification() { }

        public override Expression<Func<T, Boolean>> ToExpression() => Expression.Constant(true).Simplify<T>();
    }
}