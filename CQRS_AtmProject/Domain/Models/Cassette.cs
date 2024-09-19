using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CQRS_AtmProject.Domain.Enums;

namespace CQRS_AtmProject.Domain.Models
{
    public class Cassette
    {
        [Key]
        public int Id { get; set; }
        public int QuantityCapacity { get; set; } = 100;
        public int ExistQuantity { get; set; } = 0;
        public bool IsDepositOnly { get; set; }
        public bool IsForeignCurrencyOnly { get; set; }

        public int AtmId { get; set; }
        public Atm? Atm { get; set; }
        public List<CurrencyDenomination>? CurrencyDenominations { get; set; }
        
    }
}