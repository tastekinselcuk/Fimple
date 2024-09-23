using Microsoft.AspNetCore.Mvc;
using CQRS_AtmProject.Application.Dtos.CurrencyDenominations;
using CQRS_AtmProject.Infrastructure.Services;

namespace CQRS_AtmProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyDenominationController : ControllerBase
    {
        private readonly ICurrencyDenominationService _service;

        public CurrencyDenominationController(ICurrencyDenominationService service)
        {
            _service = service;
        }

        [HttpPost("createCurrencyDenomination")]
        public async Task<IActionResult> Create([FromBody] CurrencyDenominationDto dto)
        {
            var response = await _service.CreateCurrencyDenominationAsync(dto);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpDelete("deleteCurrencyDenomination/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _service.DeleteCurrencyDenominationAsync(id);
            if (response.Success)
            {
                return NoContent();
            }
            return NotFound(response.Message);
        }

        [HttpGet("getAllCurrencyDenominations")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAllCurrencyDenominationsAsync();
            return Ok(response);
        }

        [HttpGet("getCurrencyDenominationById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _service.GetCurrencyDenominationByIdAsync(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return NotFound(response.Message);
        }

        [HttpPut("updateCurrencyDenomination/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CurrencyDenominationDto updateDto)
        {
            var response = await _service.UpdateCurrencyDenominationAsync(id, updateDto);
            if (response.Success)
            {
                return Ok(response);
            }
            return NotFound(response.Message);
        }
    }
}
