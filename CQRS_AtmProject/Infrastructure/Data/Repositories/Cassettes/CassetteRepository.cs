using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CQRS_AtmProject.Data;
using CQRS_AtmProject.Domain.Models;

namespace CQRS_AtmProject.Infrastructure.Data.Repositories.Cassettes
{
    public class CassetteRepository : ICassetteRepository
    {
        private readonly AppDbContext _context;

        public CassetteRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Cassette>> GetAllCassettesAsync()
        {
            return await _context.Cassettes
            .Include(c => c.CurrencyDenominations)
            .ToListAsync();
        }
        public async Task<Cassette> GetCassetteByIdAsync(int id)
        {
            return await _context.Cassettes.FindAsync(id);
        }
        public async Task AddCassetteAsync(Cassette cassette)
        {
            await _context.Cassettes.AddAsync(cassette);
        }
        public async Task UpdateCassetteAsync(Cassette cassette)
        {
            _context.Cassettes.Update(cassette);
            await SaveChangesAsync();
        }
        public async Task UpdateCassettesAsync(List<Cassette> cassettes)
        {
            foreach (var cassette in cassettes)
            {
                _context.Cassettes.Update(cassette);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCassetteAsync(Cassette cassette)
        {
            _context.Cassettes.Remove(cassette);
            await SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}