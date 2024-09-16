using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserProductManagementAPI.Domain.Enums;

namespace UserProductManagementAPI.Application.Dtos.Cassettes
{
    public class CassetteDto
    {
        public int Id { get; set; }
        public int QuantityCapacity { get; set; }
        public int ExistQuantity { get; set; }
        public bool IsDepositOnly { get; set; }
        public bool IsForeignCurrencyOnly { get; set; }
        public int AtmId { get; set; }
    }
}