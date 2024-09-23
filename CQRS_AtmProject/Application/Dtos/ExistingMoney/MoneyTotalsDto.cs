using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_AtmProject.Application.Dtos.ExistingMoney
{
    public class MoneyTotalsDto
    {
        public decimal TotalUSD { get; set; }
        public decimal TotalEUR { get; set; }
        public decimal TotalTRY { get; set; }
    }

}