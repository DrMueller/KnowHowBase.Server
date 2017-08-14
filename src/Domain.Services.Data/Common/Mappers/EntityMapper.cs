using Mmu.Khb.Domain.Infrastructure.ModelAbstractions;
using Mmu.Khb.Domain.Services.Data.Infrastructure.Mapping.Mappers;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Mmu.Khb.Domain.Services.Data.Common.Mappers
{
    public class EntityMapper : IMapper
    {
        public void InitializeMapping()
        {
            BsonClassMap.RegisterClassMap<Entity>(
                f =>
                {
                    f.MapIdMember(c => c.Id).SetIdGenerator(new StringObjectIdGenerator());
                });
        }
    }
}