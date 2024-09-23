using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS_AtmProject.Domain.Enums;

namespace CQRS_AtmProject.Application.Dtos.ExistingMoney
{
    public class ExistingMoneyResponseDto
    {
    public string? DenominationType { get; set; }
    public string? CurrencyType { get; set; }
    public int Quantity { get; set; }
    }
}