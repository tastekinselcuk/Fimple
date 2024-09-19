using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CQRS_AtmProject.Data;
using CQRS_AtmProject.Domain.Models;

namespace CQRS_AtmProject.Infrastructure.Data.Repositories.Atms
{
    public class AtmRepository : IAtmRepository
    {
        private readonly AppDbContext _context;

        public AtmRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
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
            if (atm == null) 
                throw new ArgumentNullException(nameof(atm));
            
            await _context.Atms.AddAsync(atm);
            await SaveChangesAsync();
        }

        public async Task UpdateAtmAsync(Atm atm)
        {
            if (atm == null) 
                throw new ArgumentNullException(nameof(atm));

            _context.Atms.Update(atm);
            await SaveChangesAsync();
        }

        public async Task DeleteAtmAsync(Atm atm)
        {
            if (atm == null) 
                throw new ArgumentNullException(nameof(atm));

            _context.Atms.Remove(atm);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
