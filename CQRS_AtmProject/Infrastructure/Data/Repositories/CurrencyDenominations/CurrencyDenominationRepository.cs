using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserProductManagementAPI.Data;
using UserProductManagementAPI.Domain.Enums;
using UserProductManagementAPI.Domain.Models;

namespace UserProductManagementAPI.Infrastructure.Data.Repositories.CurrencyDenominations
{
    public class CurrencyDenominationRepository : ICurrencyDenominationRepository
    {
        private readonly AppDbContext _context;

        public CurrencyDenominationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CurrencyDenomination>> GetAllCurrencyDenominationsAsync()
        {
            return await _context.CurrencyDenominations.ToListAsync();
        }

        public async Task<CurrencyDenomination?> GetCurrencyDenominationByIdAsync(int id)
        {
            return await _context.CurrencyDenominations.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddCurrencyDenominationAsync(CurrencyDenomination currencyDenomination)
        {
            await _context.CurrencyDenominations.AddAsync(currencyDenomination);
        }

        public async Task UpdateCurrencyDenominationAsync(CurrencyDenomination currencyDenomination)
        {
            _context.CurrencyDenominations.Update(currencyDenomination);
        }

        public async Task DeleteCurrencyDenominationAsync(CurrencyDenomination currencyDenomination)
        {
            _context.CurrencyDenominations.Remove(currencyDenomination);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        // public async Task<decimal> GetCurrencyDenominationByCurrencyTypeAsync(string Currency)
        // {
        //     if (Enum.TryParse(typeof(CurrencyType), Currency, true, out var parsedCurrency))
        //     {
        //         return await _context.CurrencyDenominations
        //                             .Where(c => c.CurrencyType == (CurrencyType)parsedCurrency)
        //                             .SumAsync(c => c.Amount);
        //     }

        //     throw new ArgumentException("Invalid currency type");
        // }
    }
}
