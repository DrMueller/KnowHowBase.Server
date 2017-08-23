using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Khb.Domain.Infrastructure.ModelAbstractions;
using Mmu.Khb.Domain.Infrastructure.Specifications;

namespace Mmu.Khb.Domain.Services.Common.Repositories
{
    public interface IRepository<T>
        where T : AggregateRoot
    {
        Task DeleteAsync(long id);

        Task<IReadOnlyCollection<T>> LoadAllAsync();

        Task<IReadOnlyCollection<T>> LoadAsync(ISpecification<T> specification);

        Task<T> LoadByIdAsync(long id);

        Task<T> SaveAsync(T aggregateRoot);
    }
}