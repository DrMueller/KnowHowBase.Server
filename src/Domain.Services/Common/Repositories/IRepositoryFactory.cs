using Mmu.Khb.Domain.Infrastructure.ModelAbstractions;

namespace Mmu.Khb.Domain.Services.Common.Repositories
{
    public interface IRepositoryFactory
    {
        IRepository<T> CreateRepository<T>()
            where T : AggregateRoot;
    }
}