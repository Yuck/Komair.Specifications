using System;
using System.Linq.Expressions;

namespace Komair.Specifications.Abstract
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T t);

        ISpecification<T> And(ISpecification<T> specification);
        ISpecification<T> Not();
        ISpecification<T> Or(ISpecification<T> specification);
        Expression<Func<T, bool>> ToExpression();
    }
}