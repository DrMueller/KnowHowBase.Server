using Mmu.Khb.Common.ApplicationSettings.Models;
using Mmu.Khb.Common.ApplicationSettings.Services;
using Mmu.Khb.Domain.Infrastructure.ModelAbstractions;
using MongoDB.Driver;

namespace Mmu.Khb.Domain.Services.Data.Common.Repositories.Handlers.Implementation
{
    public class MongoDbAccess : IMongoDbAccess
    {
        private readonly IMongoClientFactory _mongoClientFactory;
        private readonly MongoDbSettings _mongoDbSettings;

        public MongoDbAccess(IMongoClientFactory mongoClientFactory, IAppSettingsProvider appSettingsProvider)
        {
            _mongoClientFactory = mongoClientFactory;
            _mongoDbSettings = appSettingsProvider.GetAppSettings().MongoDbSettings;
        }

        public IMongoCollection<T> GetDatabaseCollection<T>()
            where T : AggregateRoot
        {
            var db = GetDatabase();
            var result = db.GetCollection<T>(_mongoDbSettings.CollectionName);

            return result;
        }

        private IMongoDatabase GetDatabase()
        {
            var mongoClient = _mongoClientFactory.Create();
            var database = mongoClient.GetDatabase(_mongoDbSettings.DatabaseName);
            return database;
        }
    }
}