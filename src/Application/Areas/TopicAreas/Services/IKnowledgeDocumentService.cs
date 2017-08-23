using System.Threading.Tasks;
using Mmu.Khb.Application.Areas.TopicAreas.Dtos;

namespace Mmu.Khb.Application.Areas.TopicAreas.Services
{
    public interface IKnowledgeDocumentService
    {
        Task<KnowledgeDocumentDto> LoadByIdAsync(long id);

        Task<KnowledgeDocumentDto> SaveAsync(KnowledgeDocumentDto dto);
    }
}