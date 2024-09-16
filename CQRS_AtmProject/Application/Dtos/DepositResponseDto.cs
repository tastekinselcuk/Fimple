namespace UserProductManagementAPI.Application.Dtos
{
    public class DepositResponseDto
    {
        public int CassetteId { get; set; }
        public int DepositedAmount { get; set; }
        public int RemainingCapacity { get; set; }
    }
}
