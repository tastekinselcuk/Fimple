using System.Collections.Generic;
using System.Threading.Tasks;
using UserProductManagementAPI.Application.Dtos.Cassettes;
using UserProductManagementAPI.Domain.Models;

namespace UserProductManagementAPI.Infrastructure.Services
{
    public interface ICassetteService
    {
        Task<ServiceResponse<List<CassetteDto>>> GetAllCassettesAsync();
        Task<ServiceResponse<CassetteDto>> GetCassetteByIdAsync(int id);
        Task<ServiceResponse<CassetteDto>> CreateCassetteAsync(CreateCassetteDto createCassetteDto);
        Task<ServiceResponse<CassetteDto>> UpdateCassetteAsync(UpdateCassetteDto updateCassetteDto);
        Task<ServiceResponse<bool>> DeleteCassetteAsync(int id);
        //other
        Task<ServiceResponse<decimal>> GetCassetteAmountByCurrencyTypeAndId(int id, string CurrencyType); 

    }
}
