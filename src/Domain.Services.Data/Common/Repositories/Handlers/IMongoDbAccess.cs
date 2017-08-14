using Mmu.Khb.Domain.Infrastructure.ModelAbstractions;
using MongoDB.Driver;

namespace Mmu.Khb.Domain.Services.Data.Common.Repositories.Handlers
{
    public interface IMongoDbAccess
    {
        IMongoCollection<T> GetDatabaseCollection<T>()
            where T : AggregateRoot;
    }
}