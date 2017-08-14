using System.Collections.Generic;
using System.Linq;
using Mmu.Khb.Common.ServiceProvisioning;
using Mmu.Khb.Domain.Services.Data.Infrastructure.Mapping.Mappers;
using MongoDB.Bson.Serialization;

namespace Mmu.Khb.Domain.Services.Data.Infrastructure.Mapping.Implementation
{
    public class MappingInitializationService : IMappingInitializationService
    {
        private readonly object _lock = new object();
        private readonly IReadOnlyCollection<IMapper> _mappers;

        public MappingInitializationService(IProvisioningService provisioningService)
        {
            _mappers = provisioningService.GetAllServices<IMapper>();
        }

        public void AssureMappinsgAreInitialized()
        {
            if (BsonClassMap.GetRegisteredClassMaps().Any())
            {
                return;
            }

            lock (_lock)
            {
                if (BsonClassMap.GetRegisteredClassMaps().Any())
                {
                    return;
                }

                foreach (var mapper in _mappers)
                {
                    mapper.InitializeMapping();
                }
            }
        }
    }
}