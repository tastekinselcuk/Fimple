using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserProductManagementAPI.Data;
using UserProductManagementAPI.Domain.Models;

namespace UserProductManagementAPI.Infrastructure.Data.Repositories.Atms
{
    public class AtmRepository : IAtmRepository
    {
        private readonly AppDbContext _context;

        public AtmRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Atm>> GetAllAtmsAsync()
        {
            return await _context.Atms
            .Include(a => a.Cassettes)
            .ToListAsync();
        }

        public async Task<Atm?> GetAtmByIdAsync(int id)
        {
            return await _context.Atms
                .Include(a => a.Cassettes)
                .ThenInclude(c => c.CurrencyDenominations)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddAtmAsync(Atm atm)
        {
            await _context.Atms.AddAsync(atm);
        }

        public async Task UpdateAtmAsync(Atm atm)
        {
            _context.Atms.Update(atm);
        }

        public async Task DeleteAtmAsync(Atm atm)
        {
            _context.Atms.Remove(atm);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }


    }
}