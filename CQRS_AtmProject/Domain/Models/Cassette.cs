using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UserProductManagementAPI.Domain.Enums;

namespace UserProductManagementAPI.Domain.Models
{
    public class Cassette
    {
        public int Id { get; set; }
        public int QuantityCapacity { get; set; } = 100;
        public int ExistQuantity { get; set; }
        public bool IsDepositOnly { get; set; }
        public bool IsForeignCurrencyOnly { get; set; }

        public int AtmId { get; set; }
        public Atm Atm { get; set; }
        public List<CurrencyDenomination> CurrencyDenominations { get; set; }
        
    }
}