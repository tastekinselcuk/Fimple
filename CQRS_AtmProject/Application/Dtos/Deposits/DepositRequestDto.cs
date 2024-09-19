using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS_AtmProject.Domain.Enums;

namespace CQRS_AtmProject.Application.Dtos
{
    public class DepositRequestDto
    {
    public int AtmId { get; set; }
    public string? DenominationType { get; set; }  // 20, 50, 100, 500
    public string? CurrencyType { get; set; } // USD, EUR, TRY
    public int Quantity { get; set; }
        
    }
}