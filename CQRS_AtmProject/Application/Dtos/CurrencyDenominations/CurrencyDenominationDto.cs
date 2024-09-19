namespace CQRS_AtmProject.Application.Dtos.CurrencyDenominations
{
    public class CurrencyDenominationDto
    {
        public string? DenominationType { get; set; }
        public string? CurrencyType { get; set; }
        public int Quantity { get; set; }
    }
}
