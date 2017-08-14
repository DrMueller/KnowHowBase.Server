using Mmu.Khb.Domain.Infrastructure.ModelAbstractions;
using Mmu.Khb.Domain.Services.Data.Infrastructure.Mapping.Mappers;
using MongoDB.Bson.Serialization;

namespace Mmu.Khb.Domain.Services.Data.Common.Mappers
{
    public class AggregateRootMapper : IMapper
    {
        public void InitializeMapping()
        {
            BsonClassMap.RegisterClassMap<AggregateRoot>(
                f =>
                {
                    f.MapMember(c => c.AggregateTypeName);
                });
        }
    }
}