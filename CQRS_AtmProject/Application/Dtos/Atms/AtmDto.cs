using System.Collections.Generic;
using CQRS_AtmProject.Application.Dtos.Cassettes;

namespace CQRS_AtmProject.Application.Dtos.Atms
{
    public class AtmDto
    {
        public int DepositOnlyCount { get; set; }
        public int ForeignCurrencyOnlyCount { get; set; }
        public int TotalCassette { get; set; }
        public List<CassetteDto>? Cassettes { get; set; }
    }
}
