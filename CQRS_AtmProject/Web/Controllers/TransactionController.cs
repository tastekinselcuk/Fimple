using CQRS_AtmProject.Application.Dtos;
using CQRS_AtmProject.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CQRS_AtmProject.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _service;

        public TransactionController(ITransactionService service)
        {
            _service = service;
        }

        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit([FromBody] DepositRequestDto depositRequestDto)
        {
            var response = await _service.Deposit(depositRequestDto);
            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }

        [HttpPost("withdrawal")]
        public async Task<IActionResult> Withdrawal([FromBody] WithdrawalRequestDto withdrawalRequestDto)
        {
            var response = await _service.Withdrawal(withdrawalRequestDto);
            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }

        [HttpGet("{cassetteId}")]
        public async Task<IActionResult> ExistingMoney(int cassetteId)
        {
            var response = await _service.ExistingMoney(cassetteId);
            return Ok(response.Data);
        }

        [HttpPost("reset-atm/{atmId}")]
        public async Task<IActionResult> ResetAtm(int atmId)
        {
            var response = await _service.ResetAtm(atmId);
            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }
    }
}
