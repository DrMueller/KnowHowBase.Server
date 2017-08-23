using Mmu.Khb.Domain.Infrastructure.ModelAbstractions;

namespace Mmu.Khb.Domain.Areas.TopicAreas.Models
{
    public sealed class KnowledgeDocument : AggregateRoot
    {
        public KnowledgeDocument(long id, string markdownText)
        {
            MarkdownText = markdownText;
            Id = id;
        }

        public string MarkdownText { get; private set; }
    }
}