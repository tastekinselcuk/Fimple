using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserProductManagementAPI.Data;
using UserProductManagementAPI.Domain.Models;

namespace UserProductManagementAPI.Infrastructure.Data.Repositories.Cassettes
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
            return await _context.Cassettes.ToListAsync();
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
        }
        public async Task DeleteCassetteAsync(Cassette cassette)
        {
            _context.Cassettes.Remove(cassette);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}