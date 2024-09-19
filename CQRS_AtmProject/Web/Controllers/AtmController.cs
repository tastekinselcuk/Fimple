using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CQRS_AtmProject.Application.Dtos;
using CQRS_AtmProject.Application.Dtos.Atms;
using CQRS_AtmProject.Infrastructure.Services;

namespace CQRS_AtmProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtmController : ControllerBase
    {
        private readonly IAtmService _atmService;

        public AtmController(IAtmService atmService)
        {
            _atmService = atmService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAtmById(int id)
        {
            var response = await _atmService.GetAtmByIdAsync(id);
            if (!response.Success)
                return NotFound(response.Message);

            return Ok(response.Data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAtms()
        {
            var response = await _atmService.GetAllAtmsAsync();
            return Ok(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAtm([FromBody] CreateAtmDto createAtmDto)
        {
            var response = await _atmService.CreateAtmAsync(createAtmDto);
            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAtm(int id, [FromBody] UpdateAtmDto updateAtmDto)
        {
            var response = await _atmService.UpdateAtmAsync(id, updateAtmDto);
            if (!response.Success)
                return NotFound(response.Message);

            return Ok(response.Data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAtm(int id)
        {
            var response = await _atmService.DeleteAtmAsync(id);
            if (!response.Success)
                return NotFound(response.Message);

            return NoContent();
        }

    }
}
