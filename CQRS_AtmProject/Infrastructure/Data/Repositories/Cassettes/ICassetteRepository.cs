using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserProductManagementAPI.Domain.Models;

namespace UserProductManagementAPI.Infrastructure.Data.Repositories.Cassettes
{
    public interface ICassetteRepository
    {
        Task AddCassetteAsync(Cassette cassette);
        Task UpdateCassetteAsync(Cassette cassette);
        Task DeleteCassetteAsync(Cassette cassette);
        Task<List<Cassette>> GetAllCassettesAsync();
        Task<Cassette> GetCassetteByIdAsync(int id);
        Task SaveChangesAsync();

    }
}