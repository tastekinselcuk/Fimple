using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS_AtmProject.Domain.Models;

namespace CQRS_AtmProject.Infrastructure.Data.Repositories.Atms
{
    public interface IAtmRepository
    {
        Task AddAtmAsync(Atm atm);
        Task UpdateAtmAsync(Atm atm);
        Task DeleteAtmAsync(Atm atm);
        Task<List<Atm>> GetAllAtmsAsync();
        Task<Atm> GetAtmByIdAsync(int id);
        Task SaveChangesAsync();

    }
}