using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_AtmProject.Application.Dtos.ExistingMoney
{
    public class ExistingMoneyDto
    {
        public string DenominationType { get; set; }
        public string CurrencyType { get; set; }
        public int Quantity { get; set; }
        public decimal TotalValue { get; set; }
    }
}