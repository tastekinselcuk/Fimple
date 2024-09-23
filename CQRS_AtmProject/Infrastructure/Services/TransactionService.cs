using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CQRS_AtmProject.Application.Atms.Queries;
using CQRS_AtmProject.Application.Dtos;
using CQRS_AtmProject.Application.Dtos.CurrencyDenominations;
using CQRS_AtmProject.Application.Dtos.ExistingMoney;
using CQRS_AtmProject.Application.Transactions.Command;
using CQRS_AtmProject.Application.Transactions.Commands;
using CQRS_AtmProject.Application.Transactions.Query;
using CQRS_AtmProject.Domain.Models;
using CQRS_AtmProject.Infrastructure.Data.Repositories.Atms;
using MediatR;

namespace CQRS_AtmProject.Infrastructure.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IMediator _mediator;
        private readonly IAtmRepository _atmRepository;
        private readonly IMapper _mapper;

        public TransactionService(IMediator mediator, IAtmRepository atmRepository, IMapper mapper)
        {
            _mediator = mediator;
            _atmRepository = atmRepository;
            _mapper = mapper;
        }


        public async Task<ServiceResponse<DepositResponseDto>> Deposit(DepositRequestDto depositRequestDto)
        {
            var command = _mapper.Map<DepositCommand>(depositRequestDto);
            var result = await _mediator.Send(command);
            
            return result;
        }

        public async Task<ServiceResponse<WithdrawalResponseDto>> Withdrawal(WithdrawalRequestDto withdrawalRequestDto)
        {
            var command = _mapper.Map<WithdrawalCommand>(withdrawalRequestDto);
            var result = await _mediator.Send(command);
            
            return result;
        }

        public async Task<ServiceResponse<List<ExistingMoneyDto>>> DetailedExistingMoneyasync(int atmId)
        {
            var command = new DetailedExistingAtmMoneyQuery { AtmId = atmId };
            var result = await _mediator.Send(command);
            
            return result;
        }

        public async Task<ServiceResponse<MoneyTotalsDto>> ExistingAtmMoney(int atmId)
        {
            var command = new ExistingMoneyQuery { AtmId = atmId };
            var result = await _mediator.Send(command);
            
            return result;
        }

        // public Task<ServiceResponse<decimal>> GetAtmAmountById()
        // {
        //     throw new NotImplementedException();
        // }

        public async Task<ServiceResponse<bool>> ResetAtm(int atmId)
        {
            var command = new ResetAtmCommand { AtmId = atmId };
            var result = await _mediator.Send(command);
            return result;
        }
    }
}