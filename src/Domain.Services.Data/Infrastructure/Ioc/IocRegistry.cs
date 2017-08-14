using Mmu.Khb.Domain.Services.Common.Repositories;
using Mmu.Khb.Domain.Services.Data.Common.Repositories;
using Mmu.Khb.Domain.Services.Data.Common.Repositories.Handlers;
using Mmu.Khb.Domain.Services.Data.Common.Repositories.Handlers.Implementation;
using Mmu.Khb.Domain.Services.Data.Infrastructure.Mapping;
using Mmu.Khb.Domain.Services.Data.Infrastructure.Mapping.Implementation;
using Mmu.Khb.Domain.Services.Data.Infrastructure.Mapping.Mappers;
using StructureMap;

namespace Mmu.Khb.Domain.Services.Data.Infrastructure.Ioc
{
    public class IocRegistry : Registry
    {
        public IocRegistry()
        {
            Scan(
                scan =>
                {
                    scan.TheCallingAssembly(); // Scan this assembly
                    scan.AddAllTypesOf(typeof(IRepository<>));
                    scan.AddAllTypesOf(typeof(IMongoDbFilterDefinitionFactory<>));
                    scan.AddAllTypesOf<IMapper>();
                    scan.WithDefaultConventions();
                });

            For<IRepositoryFactory>().Use<RepositoryFactory>().Singleton();
            For<IMappingInitializationService>().Use<MappingInitializationService>().Singleton();
            For<IMongoClientFactory>().Use<MongoClientFactory>().Singleton();
        }
    }
}