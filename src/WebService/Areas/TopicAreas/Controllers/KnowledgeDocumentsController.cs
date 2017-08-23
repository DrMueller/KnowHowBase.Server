using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mmu.Khb.Application.Areas.TopicAreas.Dtos;
using Mmu.Khb.Application.Areas.TopicAreas.Services;

namespace Mmu.Khb.WebService.Areas.TopicAreas.Controllers
{
    [Route("api/[controller]")]
    public class KnowledgeDocumentsController : Controller
    {
        private readonly IKnowledgeDocumentService _knowledgeDocumentService;

        public KnowledgeDocumentsController(IKnowledgeDocumentService knowledgeDocumentService)
        {
            _knowledgeDocumentService = knowledgeDocumentService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetKnowledgeDocument(long id)
        {
            var result = await _knowledgeDocumentService.LoadByIdAsync(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateKnowledgeDocument([FromBody] KnowledgeDocumentDto dto)
        {
            var result = await _knowledgeDocumentService.SaveAsync(dto);
            return Ok(result);
        }
    }
}