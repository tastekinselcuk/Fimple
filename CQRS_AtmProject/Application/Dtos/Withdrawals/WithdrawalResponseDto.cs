using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_AtmProject.Application.Dtos
{
    public class WithdrawalResponseDto
    {
    public decimal WithdrawalAmount { get; set; }
    public List<WithdrawalDetailDto>? Details { get; set; }
    }
}