using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS_AtmProject.Application.Dtos.CurrencyDenominations;
using CQRS_AtmProject.Domain.Models;

namespace CQRS_AtmProject.Infrastructure.Services
{
    public interface ICurrencyDenominationService
    {
        Task<ServiceResponse<CurrencyDenominationDto>> CreateCurrencyDenominationAsync(CreateCurrencyDenominationDto dto);
        Task<ServiceResponse<CurrencyDenominationDto>> GetCurrencyDenominationByIdAsync(int id);
        Task<ServiceResponse<List<CurrencyDenominationDto>>> GetAllCurrencyDenominationsAsync();
        Task<ServiceResponse<CurrencyDenominationDto>> UpdateCurrencyDenominationAsync(int id, UpdateCurrencyDenominationDto updateDto);
        Task<ServiceResponse<bool>> DeleteCurrencyDenominationAsync(int id);
    }
}