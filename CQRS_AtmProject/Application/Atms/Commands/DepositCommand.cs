using System;
using MediatR;
using UserProductManagementAPI.Application.Dtos;
using UserProductManagementAPI.Domain.Models;

namespace UserProductManagementAPI.Application.Atms.Commands
{
    public class DepositCommand : IRequest<ServiceResponse<DepositResponseDto>>
    {
        public int AtmId { get; set; }
        public int Quantity { get; set; }
        public string DenominationType { get; set; }
        public string CurrencyType { get; set; }
    }
}
