using System;
using System.Linq.Expressions;

namespace Komair.Specifications.Abstract;

public abstract class BinarySpecificationBase<T> : SpecificationBase<T>
{
    protected ISpecification<T> Left;
    protected ISpecification<T> Right;

    protected BinarySpecificationBase(ISpecification<T> left, ISpecification<T> right)
    {
        Left = left ?? throw new ArgumentNullException(nameof(left));
        Right = right ?? throw new ArgumentNullException(nameof(right));
    }

    public override Expression<Func<T, Boolean>> ToExpression() => GetLambda(GetBinaryExpression());

    protected abstract BinaryExpression GetBinaryExpression();
}
