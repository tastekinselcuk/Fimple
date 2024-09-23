using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CQRS_AtmProject.Application.Dtos;
using CQRS_AtmProject.Application.Dtos.Cassettes;
using CQRS_AtmProject.Infrastructure.Services;

namespace CQRS_AtmProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CassetteController : ControllerBase
    {
        private readonly ICassetteService _cassetteService;

        public CassetteController(ICassetteService cassetteService)
        {
            _cassetteService = cassetteService;
        }

        [HttpGet("getAllCassettes")]
        public async Task<IActionResult> GetAllCassettes()
        {
            var response = await _cassetteService.GetAllCassettesAsync();
            if (response.Success)
                return Ok(response.Data);
            return BadRequest(response.Message);
        }

        [HttpGet("getCassetteById/{id}")]
        public async Task<IActionResult> GetCassetteById(int id)
        {
            var response = await _cassetteService.GetCassetteByIdAsync(id);
            if (response.Success)
                return Ok(response.Data);
            return NotFound(response.Message);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCassette([FromBody] CassetteDto createCassetteDto)
        {
            var response = await _cassetteService.CreateCassetteAsync(createCassetteDto);
            if (response.Success)
                return CreatedAtAction(nameof(GetCassetteById), new { id = response.Data }, response.Data);
            return BadRequest(response.Message);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCassette([FromBody] CassetteDto updateCassetteDto)
        {
            var response = await _cassetteService.UpdateCassetteAsync(updateCassetteDto);
            if (response.Success)
                return NoContent();
            return BadRequest(response.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCassette(int id)
        {
            var response = await _cassetteService.DeleteCassetteAsync(id);
            if (response.Success)
                return NoContent();
            return BadRequest(response.Message);
        }
    }
}
