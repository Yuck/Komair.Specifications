using System;
using System.Linq.Expressions;
using Komair.Specifications.Internal;

namespace Komair.Specifications.Abstract
{
    public abstract class SpecificationBase<T> : ISpecification<T>
    {
        private readonly Lazy<Func<T, bool>> _predicate;

        protected SpecificationBase()
        {
            _predicate = new Lazy<Func<T, bool>>(() => ToExpression().Compile());
        }

        public static implicit operator Expression<Func<T, bool>>(SpecificationBase<T> specification)
        {
            return specification.ToExpression();
        }

        public ISpecification<T> And(ISpecification<T> specification)
        {
            return new AndSpecification<T>(this, specification);
        }

        public bool IsSatisfiedBy(T t)
        {
            return _predicate.Value(t);
        }

        public ISpecification<T> Not()
        {
            return new NotSpecification<T>(this);
        }

        public ISpecification<T> Or(ISpecification<T> specification)
        {
            return new OrSpecification<T>(this, specification);
        }

        public Expression<Func<T, bool>> Where(Expression<Func<T, bool>> predicate)
        {
            return Expression.Lambda<Func<T, bool>>(And(new ExpressionSpecification<T>(predicate)).ToExpression());
        }

        public abstract Expression<Func<T, bool>> ToExpression();
    }
}