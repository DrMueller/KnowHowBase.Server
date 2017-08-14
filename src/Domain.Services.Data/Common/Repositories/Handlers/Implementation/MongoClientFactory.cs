using System.Collections.Generic;
using System.Security.Authentication;
using Mmu.Khb.Common.ApplicationSettings.Models;
using Mmu.Khb.Common.ApplicationSettings.Services;
using Mmu.Khb.Domain.Services.Data.Infrastructure.Mapping;
using MongoDB.Driver;

namespace Mmu.Khb.Domain.Services.Data.Common.Repositories.Handlers.Implementation
{
    public class MongoClientFactory : IMongoClientFactory
    {
        private readonly MongoDbSettings _mongoDbSettings;

        public MongoClientFactory(IAppSettingsProvider appSettingsProvider, IMappingInitializationService mappingInitializationService)
        {
            mappingInitializationService.AssureMappinsgAreInitialized();
            _mongoDbSettings = appSettingsProvider.GetAppSettings().MongoDbSettings;
        }

        public MongoClient Create()
        {
            var clientSettings = new MongoClientSettings
            {
                Server = new MongoServerAddress(_mongoDbSettings.Host, _mongoDbSettings.Port),
                UseSsl = _mongoDbSettings.UseSsl
            };

            if (clientSettings.UseSsl)
            {
                clientSettings.SslSettings = new SslSettings
                {
                    EnabledSslProtocols = SslProtocols.Tls12
                };
            }

            var identity = new MongoInternalIdentity(_mongoDbSettings.DatabaseName, _mongoDbSettings.UserName);
            var evidence = new PasswordEvidence(_mongoDbSettings.Password);
            clientSettings.Credentials = new List<MongoCredential>
            {
                new MongoCredential("SCRAM-SHA-1", identity, evidence)
            };

            var mongoClient = new MongoClient(clientSettings);
            return mongoClient;
        }
    }
}