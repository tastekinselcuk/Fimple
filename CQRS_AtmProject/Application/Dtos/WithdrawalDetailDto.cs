using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserProductManagementAPI.Application.Dtos
{
    public class WithdrawalDetailDto
    {
    public int CassetteId { get; set; }
    public int DenominationType { get; set; }
    public string CurrencyType { get; set; }
    public int WithdrawnQuantity { get; set; }
    }
}