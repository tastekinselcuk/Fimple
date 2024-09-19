using System.Collections.Generic;

namespace CQRS_AtmProject.Application.Dtos.Atms
{
    public class UpdateAtmDto
    {
        public int DepositOnlyCount { get; set; }
        public int ForeignCurrencyOnlyCount { get; set; }
        public int TotalCassette { get; set; }
        public List<int>? CassetteIds { get; set; }
    }
}
