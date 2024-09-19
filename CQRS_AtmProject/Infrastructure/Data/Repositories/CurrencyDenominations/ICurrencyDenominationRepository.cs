using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS_AtmProject.Domain.Models;

namespace CQRS_AtmProject.Infrastructure.Data.Repositories.CurrencyDenominations
{
    public interface ICurrencyDenominationRepository
    {
        Task<List<CurrencyDenomination>> GetAllCurrencyDenominationsAsync();
        Task<CurrencyDenomination> GetCurrencyDenominationByIdAsync(int id);
        Task<List<CurrencyDenomination>> GetCurrencyDenominationsByCassetteIdAsync(int cassetteId);
        // Task<decimal> GetCurrencyDenominationByCurrencyAsync(string Currency);
        Task AddCurrencyDenominationAsync(CurrencyDenomination currencyDenomination);
        Task UpdateCurrencyDenominationAsync(CurrencyDenomination currencyDenomination);
        Task DeleteCurrencyDenominationAsync(CurrencyDenomination currencyDenomination);
        Task SaveChangesAsync();
        
    }
}