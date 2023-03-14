using System.Linq.Expressions;
using Komair.Specifications.Abstract;

namespace Komair.Specifications.Internal;

internal class AndSpecification<T> : BinarySpecificationBase<T>
{
    public AndSpecification(ISpecification<T> left, ISpecification<T> right) : base(left, right) { }

    protected override BinaryExpression GetBinaryExpression() => Expression.AndAlso(Left.ToExpression().Body, Right.ToExpression().Body);
}
