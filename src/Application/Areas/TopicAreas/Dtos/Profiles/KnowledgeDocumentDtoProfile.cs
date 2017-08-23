using AutoMapper;
using Mmu.Khb.Common.ServiceProvisioning;
using Mmu.Khb.Domain.Areas.TopicAreas.Models;
using Mmu.Khb.Domain.Services.Areas.TopicAreas.Factories;

namespace Mmu.Khb.Application.Areas.TopicAreas.Dtos.Profiles
{
    public class KnowledgeDocumentDtoProfile : Profile
    {
        public KnowledgeDocumentDtoProfile()
        {
            CreateMap<KnowledgeDocument, KnowledgeDocumentDto>();

            CreateMap<KnowledgeDocumentDto, KnowledgeDocument>()
                .ConstructUsing(
                    dto =>
                    {
                        var knowledgeDocumentFactory = ProvisioningServiceSingleton.Instance.GetService<IKnowledgeDocumentFactory>();

                        return knowledgeDocumentFactory.CreateKnowledgeDocument(dto.Id, dto.MarkdownText);
                    });
        }
    }
}