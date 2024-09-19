using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS_AtmProject.Application.Dtos.CurrencyDenominations;
using CQRS_AtmProject.Domain.Enums;
using CQRS_AtmProject.Domain.Models;

namespace CQRS_AtmProject.Application.Dtos.Cassettes
{
    public class CassetteDto
    {
        public int QuantityCapacity { get; set; }
        public int ExistQuantity { get; set; }
        public bool IsDepositOnly { get; set; }
        public bool IsForeignCurrencyOnly { get; set; }
        public List<CurrencyDenominationDto>? CurrencyDenominations { get; set; }

    }
}