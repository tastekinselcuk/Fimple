using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserProductManagementAPI.Domain.Models
{
    public class Atm
    {
        public int Id { get; set; }
        public int DepositOnlyCount { get; set; }
        public int ForeignCurrencyOnlyCount { get; set; }
        public int TotalCassette { get; set; }
        
        public List<Cassette> Cassettes { get; set; }
    }
}