using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserProductManagementAPI.Domain.Enums;

namespace UserProductManagementAPI.Application.Dtos
{
    public class ExistingMoneyResponseDto
    {
    public DenominationType DenominationType { get; set; }
    public CurrencyType CurrencyType { get; set; }
    public int Quantity { get; set; }
    }
}