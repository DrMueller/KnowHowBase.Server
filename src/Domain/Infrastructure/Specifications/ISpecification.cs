using System;
using System.Linq.Expressions;
using Mmu.Khb.Domain.Infrastructure.ModelAbstractions;

namespace Mmu.Khb.Domain.Infrastructure.Specifications
{
    public interface ISpecification<T>
        where T : AggregateRoot
    {
        bool IsSatisfiedBy(T aggregateRoot);

        Expression<Func<T, bool>> ToExpression();
    }
}