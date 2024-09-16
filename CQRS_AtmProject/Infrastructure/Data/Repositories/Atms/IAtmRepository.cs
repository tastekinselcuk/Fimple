using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserProductManagementAPI.Domain.Models;

namespace UserProductManagementAPI.Infrastructure.Data.Repositories.Atms
{
    public interface IAtmRepository
    {
        Task AddAtmAsync(Atm atm);
        Task UpdateAtmAsync(Atm atm);
        Task DeleteAtmAsync(Atm atm);
        Task<List<Atm>> GetAllAtmsAsync();
        // Task<Atm> GetAtmWithCassetesAsync(int id);
        Task<Atm> GetAtmByIdAsync(int id);
        Task SaveChangesAsync();

    }
}