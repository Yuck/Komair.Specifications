using System;
using System.Linq.Expressions;
using Komair.Specifications.Abstract;

namespace Komair.Specifications
{
    // TODO: Needs unit tests (be sure to use TrueSpecification<T>.Identity)
    public class TrueSpecification<T> : SpecificationBase<T>
    {
        private static readonly Lazy<TrueSpecification<T>> IdentityInstance = new Lazy<TrueSpecification<T>>(() => new TrueSpecification<T>());

        public static TrueSpecification<T> Identity => IdentityInstance.Value;

        private TrueSpecification() { }

        public override Expression<Func<T, Boolean>> ToExpression() => Expression.Lambda<Func<T, Boolean>>(Expression.Constant(true));
    }
}