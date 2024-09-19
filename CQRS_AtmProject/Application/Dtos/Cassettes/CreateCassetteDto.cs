using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS_AtmProject.Domain.Enums;

namespace CQRS_AtmProject.Application.Dtos.Cassettes
{
    public class CreateCassetteDto
    {
        public int QuantityCapacity { get; set; }
        public int ExistQuantity { get; set; }
        public List<string>? CurrencyType { get; set; }
        public bool IsDepositOnly { get; set; }
        public bool IsForeignCurrencyOnly { get; set; }
        public int AtmId { get; set; }
    }
}