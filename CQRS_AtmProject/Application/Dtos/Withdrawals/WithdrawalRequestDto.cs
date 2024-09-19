using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS_AtmProject.Domain.Enums;

namespace CQRS_AtmProject.Application.Dtos
{
    public class WithdrawalRequestDto
    {
    public int AtmId { get; set; }
    public decimal Amount { get; set; }
    public string? CurrencyType { get; set; }
    }
}