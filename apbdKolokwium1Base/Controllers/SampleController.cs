using apbdKolokwium1Base.DTOs;
using apbdKolokwium1Base.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apbdKolokwium1Base.Controllers
{
    [Route("api/[controller]")] // Url path. Here /api/Sample
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly ISampleDbService _dbService;

        public SampleController(ISampleDbService dbService)
        {
            _dbService = dbService;
        }
        
        [HttpGet]
        public async Task<IActionResult> SampleGet()
        {
            List<SampleDto> list = await _dbService.SampleSelectWithTranscation();
            //here u test requirements n such
            if (list.Count == 0) return NotFound();
            return Ok(_dbService.SampleSelectWithTranscation());
        }
        
        [Route("{id}/rentals")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _dbService.SampleSelectWithTranscation();
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        
        [Route("{id}/rentals")]
        [HttpPost]
        public async Task<IActionResult> SamplePost([FromRoute] int id, [FromBody] SampleDto dto)
        {
            if (String.IsNullOrEmpty(dto.SampleString))
            {
                return BadRequest("At least one item is required.");
            }
            
            try
            {
                await _dbService.SampleSelectWithTranscation();
                return Created();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
            
        }
    }
}
