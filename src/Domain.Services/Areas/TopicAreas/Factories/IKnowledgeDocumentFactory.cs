using Mmu.Khb.Domain.Areas.TopicAreas.Models;

namespace Mmu.Khb.Domain.Services.Areas.TopicAreas.Factories
{
    public interface IKnowledgeDocumentFactory
    {
        KnowledgeDocument CreateKnowledgeDocument(long id, string markdownText);
    }
}