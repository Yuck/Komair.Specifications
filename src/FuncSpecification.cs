using System;
using Komair.Specifications.Abstract;

namespace Komair.Specifications
{
    public class FuncSpecification<T> : SpecificationBase<T>
    {
        private readonly Func<T, bool> _func;

        public FuncSpecification(Func<T, bool> func)
        {
            _func = func ?? throw new ArgumentNullException(nameof(func));
        }

        public override bool IsSatisfiedBy(T t)
        {
            return _func(t);
        }
    }
}