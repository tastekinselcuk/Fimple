using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using CQRS_AtmProject.Application.Dtos.Cassettes;
using CQRS_AtmProject.Domain.Enums;
using CQRS_AtmProject.Domain.Models;

namespace CQRS_AtmProject.Application.Cassettes.Command
{
    public class UpdateCassetteCommand : IRequest<ServiceResponse<CassetteDto>>
    {
        public int Id { get; set; }
        public int QuantityCapacity { get; set; }
        public List<CurrencyType>? CurrencyType { get; set; }
        public bool IsDepositOnly { get; set; }
        public bool IsForeignCurrencyOnly { get; set; }
        public int AtmId { get; set; }
    }
}