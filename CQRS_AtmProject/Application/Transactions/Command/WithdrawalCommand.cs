using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS_AtmProject.Application.Dtos;
using CQRS_AtmProject.Domain.Models;
using MediatR;

namespace CQRS_AtmProject.Application.Transactions.Command
{
    public class WithdrawalCommand : IRequest<ServiceResponse<WithdrawalResponseDto>>
    {
        public int AtmId { get; set; }
        public decimal Amount { get; set; }
        public string? CurrencyType { get; set; }
    }
}