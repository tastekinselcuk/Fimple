using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserProductManagementAPI.Application.Dtos.CurrencyDenominations;
using UserProductManagementAPI.Domain.Models;

namespace UserProductManagementAPI.Infrastructure.Services
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