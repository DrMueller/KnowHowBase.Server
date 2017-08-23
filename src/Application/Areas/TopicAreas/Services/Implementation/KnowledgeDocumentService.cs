using System.Threading.Tasks;
using AutoMapper;
using Mmu.Khb.Application.Areas.TopicAreas.Dtos;
using Mmu.Khb.Domain.Areas.TopicAreas.Models;
using Mmu.Khb.Domain.Services.Common.Repositories;

namespace Mmu.Khb.Application.Areas.TopicAreas.Services.Implementation
{
    public class KnowledgeDocumentService : IKnowledgeDocumentService
    {
        private readonly IRepository<KnowledgeDocument> _knowledgeDocumentRepository;
        private readonly IMapper _mapper;

        public KnowledgeDocumentService(IRepository<KnowledgeDocument> knowledgeDocumentRepository, IMapper mapper)
        {
            _knowledgeDocumentRepository = knowledgeDocumentRepository;
            _mapper = mapper;
        }

        public async Task<KnowledgeDocumentDto> LoadByIdAsync(long id)
        {
            var knowledgeDocument = await _knowledgeDocumentRepository.LoadByIdAsync(id);

            if (knowledgeDocument == null)
            {
                return new KnowledgeDocumentDto
                {
                    Id = id
                };
            }

            var result = _mapper.Map<KnowledgeDocumentDto>(knowledgeDocument);

            return result;
        }

        public async Task<KnowledgeDocumentDto> SaveAsync(KnowledgeDocumentDto dto)
        {
            var knowledgeDocument = _mapper.Map<KnowledgeDocument>(dto);
            var returnedKnowledgeDocument = await _knowledgeDocumentRepository.SaveAsync(knowledgeDocument);
            var result = _mapper.Map<KnowledgeDocumentDto>(returnedKnowledgeDocument);
            return result;
        }
    }
}