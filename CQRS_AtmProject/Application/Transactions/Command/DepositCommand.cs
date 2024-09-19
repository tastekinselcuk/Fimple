using System;
using MediatR;
using CQRS_AtmProject.Application.Dtos;
using CQRS_AtmProject.Domain.Models;

namespace CQRS_AtmProject.Application.Transactions.Commands
{
    public class DepositCommand : IRequest<ServiceResponse<DepositResponseDto>>
    {
        public int AtmId { get; set; }
        public int Quantity { get; set; }
        public string? DenominationType { get; set; }
        public string? CurrencyType { get; set; }
    }
}
