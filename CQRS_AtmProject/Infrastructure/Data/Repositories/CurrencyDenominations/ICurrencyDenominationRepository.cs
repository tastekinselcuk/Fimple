using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserProductManagementAPI.Domain.Models;

namespace UserProductManagementAPI.Infrastructure.Data.Repositories.CurrencyDenominations
{
    public interface ICurrencyDenominationRepository
    {
        Task<List<CurrencyDenomination>> GetAllCurrencyDenominationsAsync();
        Task<CurrencyDenomination> GetCurrencyDenominationByIdAsync(int id);
        // Task<decimal> GetCurrencyDenominationByCurrencyAsync(string Currency);
        Task AddCurrencyDenominationAsync(CurrencyDenomination currencyDenomination);
        Task UpdateCurrencyDenominationAsync(CurrencyDenomination currencyDenomination);
        Task DeleteCurrencyDenominationAsync(CurrencyDenomination currencyDenomination);
        Task SaveChangesAsync();
        
    }
}