using System;
using System.Linq.Expressions;
using Mmu.Khb.Domain.Infrastructure.ModelAbstractions;

namespace Mmu.Khb.Domain.Infrastructure.Specifications.Implementation
{
    public abstract class SpecificationBase<T> : ISpecification<T>
        where T : AggregateRoot
    {
        public SpecificationBase<T> And(SpecificationBase<T> specification)
        {
            return new AndSpecification<T>(this, specification);
        }

        public bool IsSatisfiedBy(T aggregateRoot)
        {
            var predicate = ToExpression().Compile();
            var result = predicate(aggregateRoot);

            return result;
        }

        public SpecificationBase<T> Not()
        {
            return new NotSpecification<T>(this);
        }

        public SpecificationBase<T> Or(SpecificationBase<T> specification)
        {
            return new OrSpecification<T>(this, specification);
        }

        public abstract Expression<Func<T, bool>> ToExpression();
    }
}