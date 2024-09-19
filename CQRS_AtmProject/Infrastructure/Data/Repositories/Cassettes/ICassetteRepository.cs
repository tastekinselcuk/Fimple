using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS_AtmProject.Domain.Models;

namespace CQRS_AtmProject.Infrastructure.Data.Repositories.Cassettes
{
    public interface ICassetteRepository
    {
        Task AddCassetteAsync(Cassette cassette);
        Task UpdateCassetteAsync(Cassette cassette);
        Task UpdateCassettesAsync(List<Cassette> cassette);
        Task DeleteCassetteAsync(Cassette cassette);
        Task<List<Cassette>> GetAllCassettesAsync();
        Task<Cassette> GetCassetteByIdAsync(int id);
        Task SaveChangesAsync();

    }
}