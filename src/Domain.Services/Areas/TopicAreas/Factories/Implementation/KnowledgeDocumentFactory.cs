using Mmu.Khb.Domain.Areas.TopicAreas.Models;

namespace Mmu.Khb.Domain.Services.Areas.TopicAreas.Factories.Implementation
{
    public class KnowledgeDocumentFactory : IKnowledgeDocumentFactory
    {
        public KnowledgeDocument CreateKnowledgeDocument(long id, string markdownText)
        {
            return new KnowledgeDocument(id, markdownText);
        }
    }
}