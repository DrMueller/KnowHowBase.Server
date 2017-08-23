using System.Collections.Generic;
using Mmu.Khb.Domain.Infrastructure.ModelAbstractions;

namespace Mmu.Khb.Domain.Common.Models
{
    public class Topic : Entity
    {
        public IReadOnlyCollection<KnowledgeBlock> KnowledgeBlocks { get; }
    }
}