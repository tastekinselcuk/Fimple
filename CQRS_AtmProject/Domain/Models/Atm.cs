using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_AtmProject.Domain.Models
{
    public class Atm
    {
        [Key]
        public int Id { get; set; }
        public int DepositOnlyCount { get; set; } = 1;
        public int ForeignCurrencyOnlyCount { get; set; } = 2;
        public int TotalCassette { get; set; } = 5;
    
        public List<Cassette> Cassettes { get; set; }
    }
}