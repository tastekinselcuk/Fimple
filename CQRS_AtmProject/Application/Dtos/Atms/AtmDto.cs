using System.Collections.Generic;
using UserProductManagementAPI.Application.Dtos.Cassettes;

namespace UserProductManagementAPI.Application.Dtos.Atms
{
    public class AtmDto
    {
        public int Id { get; set; }
        public int DepositOnlyCount { get; set; }
        public int ForeignCurrencyOnlyCount { get; set; }
        public int TotalCassette { get; set; }
        public List<CassetteDto> Cassettes { get; set; }
    }
}
