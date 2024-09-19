using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CQRS_AtmProject.Domain.Enums;

namespace CQRS_AtmProject.Domain.Models
{
    public class CurrencyDenomination
    {
        [Key]
        public int Id { get; set; }
        public DenominationType DenominationType { get; set; } // 20, 50, 100, 500
        public CurrencyType CurrencyType { get; set; } // USD, EUR, TRY
        public int Quantity { get; set; }
        
        public int CassetteId { get; set; }
        public Cassette? Cassette { get; set; }
        
    }
}