using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserProductManagementAPI.Application.Dtos;
using UserProductManagementAPI.Application.Dtos.Atms;
using UserProductManagementAPI.Domain.Models;

namespace UserProductManagementAPI.Infrastructure.Services
{
    public interface IAtmService
    {
        Task<ServiceResponse<AtmDto>> CreateAtmAsync(CreateAtmDto createAtmDto);
        Task<ServiceResponse<AtmDto>> GetAtmByIdAsync(int id);
        Task<ServiceResponse<List<AtmDto>>> GetAllAtmsAsync();
        Task<ServiceResponse<AtmDto>> UpdateAtmAsync(int id, UpdateAtmDto updateAtmDto);
        Task<ServiceResponse<bool>> DeleteAtmAsync(int id);
        //other
        Task<ServiceResponse<DepositResponseDto>> Deposit(DepositRequestDto depositRequestDto);
        Task<ServiceResponse<WithdrawalResponseDto>> Withdrawal(WithdrawalRequestDto withdrawalRequestDto);
        Task<ServiceResponse<ExistingMoneyResponseDto>> ExistingMoney();
        Task<ServiceResponse<decimal>> GetAtmAmountById();

        
    }
}
