using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserProductManagementAPI.Application.Dtos;
using UserProductManagementAPI.Application.Dtos.Atms;
using UserProductManagementAPI.Infrastructure.Services;

namespace UserProductManagementAPI.Controllers
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

            return CreatedAtAction(nameof(GetAtmById), new { id = response.Data.Id }, response.Data);
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

        [HttpPost("/deposit")]
        public async Task<IActionResult> Deposit([FromBody] DepositRequestDto depositRequestDto)
        {
            var response = await _atmService.Deposit(depositRequestDto);
            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }

        [HttpPost("withdrawal")]
        public async Task<IActionResult> Withdrawal([FromBody] WithdrawalRequestDto withdrawalRequestDto)
        {
            var response = await _atmService.Withdrawal(withdrawalRequestDto);
            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }

        [HttpGet("existingmoney")]
        public async Task<IActionResult> ExistingMoney()
        {
            var response = await _atmService.ExistingMoney();
            return Ok(response.Data);
        }
    }
}
