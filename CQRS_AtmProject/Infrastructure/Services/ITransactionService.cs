using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS_AtmProject.Application.Dtos;
using CQRS_AtmProject.Application.Dtos.CurrencyDenominations;
using CQRS_AtmProject.Domain.Models;

namespace CQRS_AtmProject.Infrastructure.Services
{
    public interface ITransactionService
    {
        Task<ServiceResponse<DepositResponseDto>> Deposit(DepositRequestDto depositRequestDto);
        Task<ServiceResponse<WithdrawalResponseDto>> Withdrawal(WithdrawalRequestDto withdrawalRequestDto);
        Task<ServiceResponse<List<CurrencyDenominationDto>>> ExistingMoney(int cassetteId);
        Task<ServiceResponse<decimal>> GetAtmAmountById();
        Task<ServiceResponse<bool>> ResetAtm(int atmId);
    }
}