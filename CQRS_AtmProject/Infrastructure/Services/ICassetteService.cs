using System.Collections.Generic;
using System.Threading.Tasks;
using CQRS_AtmProject.Application.Dtos.Cassettes;
using CQRS_AtmProject.Domain.Models;

namespace CQRS_AtmProject.Infrastructure.Services
{
    public interface ICassetteService
    {
        Task<ServiceResponse<List<CassetteDto>>> GetAllCassettesAsync();
        Task<ServiceResponse<CassetteDto>> GetCassetteByIdAsync(int id);
        Task<ServiceResponse<CassetteDto>> CreateCassetteAsync(CassetteDto createCassetteDto);
        Task<ServiceResponse<CassetteDto>> UpdateCassetteAsync(CassetteDto updateCassetteDto);
        Task<ServiceResponse<bool>> DeleteCassetteAsync(int id);
        //other
        // Task<ServiceResponse<decimal>> GetCassetteAmountByCurrencyTypeAndId(int id, string CurrencyType); 

    }
}
