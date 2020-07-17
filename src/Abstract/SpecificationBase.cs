namespace Komair.Specifications.Abstract
{
    public abstract class SpecificationBase<T> : ISpecification<T>
    {
        public abstract bool IsSatisfiedBy(T t);

        public ISpecification<T> And(ISpecification<T> specification)
        {
            return new AndSpecification<T>(this, specification);
        }

        public ISpecification<T> Not(ISpecification<T> specification)
        {
            return new NotSpecification<T>(specification);
        }

        public ISpecification<T> Or(ISpecification<T> specification)
        {
            return new OrSpecification<T>(this, specification);
        }
    }
}