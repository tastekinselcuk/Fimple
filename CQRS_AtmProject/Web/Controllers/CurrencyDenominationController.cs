using Microsoft.AspNetCore.Mvc;
using UserProductManagementAPI.Application.Dtos.CurrencyDenominations;
using UserProductManagementAPI.Infrastructure.Services;

namespace UserProductManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyDenominationsController : ControllerBase
    {
        private readonly ICurrencyDenominationService _service;

        public CurrencyDenominationsController(ICurrencyDenominationService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCurrencyDenominationDto dto)
        {
            var response = await _service.CreateCurrencyDenominationAsync(dto);
            if (response.Success)
            {
                return CreatedAtAction(nameof(GetById), new { id = response.Data.Id }, response.Data);
            }
            return BadRequest(response.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _service.DeleteCurrencyDenominationAsync(id);
            if (response.Success)
            {
                return NoContent();
            }
            return NotFound(response.Message);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAllCurrencyDenominationsAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _service.GetCurrencyDenominationByIdAsync(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return NotFound(response.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCurrencyDenominationDto updateDto)
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
