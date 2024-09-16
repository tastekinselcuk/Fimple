using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserProductManagementAPI.Domain.Enums;

namespace UserProductManagementAPI.Domain.Models
{
    public class CurrencyDenomination
    {
        public int Id { get; set; }
        public DenominationType DenominationType { get; set; } // 20, 50, 100, 500
        public CurrencyType CurrencyType { get; set; } // USD, EUR, TRY
        public int Quantity { get; set; }
        
        public int CassetteId { get; set; }
        public Cassette Cassette { get; set; }
        
    }
}