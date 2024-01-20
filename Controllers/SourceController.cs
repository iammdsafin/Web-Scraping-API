using BlogAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("api/source")]
    [ApiController]
    public class SourceController : ControllerBase
    {
        public readonly Services.SourceService _sourceService;

        public SourceController(Services.SourceService sourceService)
        {
            _sourceService = sourceService;
        }

        [HttpGet("elements")]
        public async Task<IEnumerable<Source>> GetSourceElements()
        {
            return await _sourceService.GetSourceElements();
        }
    }
}
