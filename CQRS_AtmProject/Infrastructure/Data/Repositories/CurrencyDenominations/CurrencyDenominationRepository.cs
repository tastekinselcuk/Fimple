using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CQRS_AtmProject.Data;
using CQRS_AtmProject.Domain.Enums;
using CQRS_AtmProject.Domain.Models;

namespace CQRS_AtmProject.Infrastructure.Data.Repositories.CurrencyDenominations
{
    public class CurrencyDenominationRepository : ICurrencyDenominationRepository
    {
        private readonly AppDbContext _context;

        public CurrencyDenominationRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<CurrencyDenomination>> GetAllCurrencyDenominationsAsync()
        {
            return await _context.CurrencyDenominations.ToListAsync();
        }

        public async Task<CurrencyDenomination?> GetCurrencyDenominationByIdAsync(int id)
        {
            return await _context.CurrencyDenominations.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<CurrencyDenomination>> GetCurrencyDenominationsByCassetteIdAsync(int cassetteId)
        {
            return await _context.CurrencyDenominations
                .Where(c => c.CassetteId == cassetteId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddCurrencyDenominationAsync(CurrencyDenomination currencyDenomination)
        {
            if (currencyDenomination == null) 
                throw new ArgumentNullException(nameof(currencyDenomination));
            
            await _context.CurrencyDenominations.AddAsync(currencyDenomination);
            await SaveChangesAsync();
        }

        public async Task UpdateCurrencyDenominationAsync(CurrencyDenomination currencyDenomination)
        {
            if (currencyDenomination == null) 
                throw new ArgumentNullException(nameof(currencyDenomination));

            _context.CurrencyDenominations.Update(currencyDenomination);
            await SaveChangesAsync();
        }

        public async Task DeleteCurrencyDenominationAsync(CurrencyDenomination currencyDenomination)
        {
            if (currencyDenomination == null) 
                throw new ArgumentNullException(nameof(currencyDenomination));

            _context.CurrencyDenominations.Remove(currencyDenomination);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
