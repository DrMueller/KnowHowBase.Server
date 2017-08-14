using MongoDB.Driver;

namespace Mmu.Khb.Domain.Services.Data.Common.Repositories.Handlers
{
    public interface IMongoClientFactory
    {
        MongoClient Create();
    }
}