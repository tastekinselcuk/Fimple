using System.ComponentModel.DataAnnotations;

namespace CQRS_AtmProject.Application.Dtos.CurrencyDenominations
{
    public class UpdateCurrencyDenominationDto
    {
        [Required]
        public string? DenominationType { get; set; }

        [Required]
        public string? CurrencyType { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public int Quantity { get; set; }
    }
}
