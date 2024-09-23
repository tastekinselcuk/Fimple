using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CQRS_AtmProject.Application.Dtos;
using CQRS_AtmProject.Application.Dtos.Atms;
using CQRS_AtmProject.Domain.Models;

namespace CQRS_AtmProject.Infrastructure.Services
{
    public interface IAtmService
    {
        Task<ServiceResponse<AtmDto>> CreateAtmAsync(AtmDto createAtmDto);
        Task<ServiceResponse<AtmDto>> GetAtmByIdAsync(int id);
        Task<ServiceResponse<List<AtmDto>>> GetAllAtmsAsync();
        Task<ServiceResponse<AtmDto>> UpdateAtmAsync(int id, AtmDto updateAtmDto);
        Task<ServiceResponse<bool>> DeleteAtmAsync(int id);
        
    }
}
