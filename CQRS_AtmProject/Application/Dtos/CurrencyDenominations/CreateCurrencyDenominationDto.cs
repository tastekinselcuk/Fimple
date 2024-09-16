using System.ComponentModel.DataAnnotations;

namespace UserProductManagementAPI.Application.Dtos.CurrencyDenominations
{
    public class CreateCurrencyDenominationDto
    {
        [Required]
        public string DenominationType { get; set; }

        [Required]
        public string CurrencyType { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public int Quantity { get; set; }
    }
}
