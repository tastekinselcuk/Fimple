namespace UserProductManagementAPI.Application.Dtos.CurrencyDenominations
{
    public class CurrencyDenominationDto
    {
        public int Id { get; set; }
        public string DenominationType { get; set; }
        public string CurrencyType { get; set; }
        public int Quantity { get; set; }
    }
}
