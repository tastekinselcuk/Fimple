using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserProductManagementAPI.Application.Dtos
{
    public class WithdrawalResponseDto
    {
    public decimal WithdrawalAmount { get; set; }
    public List<WithdrawalDetailDto> Details { get; set; }
    }
}