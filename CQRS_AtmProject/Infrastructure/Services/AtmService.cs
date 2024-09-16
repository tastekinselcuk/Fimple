using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UserProductManagementAPI.Application.Atms.Commands;
using UserProductManagementAPI.Application.Atms.Queries;
using UserProductManagementAPI.Application.Dtos;
using UserProductManagementAPI.Application.Dtos.Atms;
using UserProductManagementAPI.Data;
using UserProductManagementAPI.Domain.Enums;
using UserProductManagementAPI.Domain.Models;
using UserProductManagementAPI.Infrastructure.Data.Repositories.Atms;

namespace UserProductManagementAPI.Infrastructure.Services
{
    public class AtmService : IAtmService
    {
        private readonly IMediator _mediator;
        private readonly IAtmRepository _atmRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public AtmService(IMediator mediator, IAtmRepository atmRepository, IMapper mapper, AppDbContext context)
        {
            _mediator = mediator;
            _atmRepository = atmRepository;
            _mapper = mapper;
            _context = context;
        }


        public async Task<ServiceResponse<AtmDto>> GetAtmByIdAsync(int id)
        {
            var query = new GetAtmByIdQuery { Id = id };
            var atm = await _mediator.Send(query);

            return atm;
        }

        public async Task<ServiceResponse<List<AtmDto>>> GetAllAtmsAsync()
        {
            var query = new GetAllAtmsQuery();
            var atms = await _mediator.Send(query);

            return atms;
        }

        public async Task<ServiceResponse<AtmDto>> CreateAtmAsync(CreateAtmDto createAtmDto)
        {
            var command = _mapper.Map<CreateAtmCommand>(createAtmDto);
            var result = await _mediator.Send(command);

            return result;
        }

        public async Task<ServiceResponse<AtmDto>> UpdateAtmAsync(int id, UpdateAtmDto updateAtmDto)
        {
            var command = _mapper.Map<UpdateAtmCommand>(updateAtmDto);
            var result = await _mediator.Send(command);

            return result;
        }

        public async Task<ServiceResponse<bool>> DeleteAtmAsync(int id)
        {
            var command = new DeleteAtmCommand { Id = id };
            var result = await _mediator.Send(command);

            return result;
        }

        //other
        // public async Task<ServiceResponse<DepositResponseDto>> Deposit(DepositRequestDto depositRequestDto)
        // {
        //     var atm = await _atmRepository.GetAtmByIdAsync(depositRequestDto.AtmId);
        //     if (atm == null) throw new Exception("ATM not found");

        //     if (!Enum.TryParse(depositRequestDto.DenominationType, out DenominationType denominationType))
        //         throw new Exception("Invalid DenominationType provided");

        //     if (!Enum.TryParse(depositRequestDto.CurrencyType, out CurrencyType currencyType))
        //         throw new Exception("Invalid CurrencyType provided");

        //     // Kasetlerde yer olup olmadığını, sadece yabancı para kabul edip etmediğini ve gönderilen banknot türü ile boyutunu kontrol ettik
        //     var cassette = atm.Cassettes?
        //         .FirstOrDefault(c => c.ExistQuantity + depositRequestDto.Quantity <= c.QuantityCapacity &&
        //             (!c.IsForeignCurrencyOnly || (currencyType == CurrencyType.USD ||
        //             currencyType == CurrencyType.EUR)) &&
        //         (c.CurrencyDenominations != null &&
        //         c.CurrencyDenominations.Any(d =>
        //             d.DenominationType == denominationType &&
        //             d.CurrencyType == currencyType)));

        //     if (cassette == null)
        //         throw new Exception("We are unable to provide you with deposit service at this time...Please try again later");

        //     cassette.ExistQuantity += depositRequestDto.Quantity;

        //     var currencyDenomination = cassette.CurrencyDenominations
        //         .FirstOrDefault(d => d.DenominationType == denominationType && d.CurrencyType == currencyType);
                
        //     if (currencyDenomination != null)
        //     {
        //         currencyDenomination.Quantity += depositRequestDto.Quantity;
        //         // currencyDenomination'u güncellenmiş olarak işaretliyoruz
        //         _context.Entry(currencyDenomination).State = EntityState.Modified;
        //     }

        //     // Değişiklikleri veritabanına kaydediyoruz
        //     await _atmRepository.SaveChangesAsync();

        //     var depositResponseDto = new DepositResponseDto
        //     {
        //         CassetteId = cassette.Id,
        //         DepositedAmount = depositRequestDto.Quantity,
        //         RemainingCapacity = cassette.QuantityCapacity - cassette.ExistQuantity,
        //     };

        //     return new ServiceResponse<DepositResponseDto>
        //     {
        //         Data = depositResponseDto,
        //         Message = "Deposit operation completed successfully",
        //         Success = true
        //     };
        // }

        public async Task<ServiceResponse<DepositResponseDto>> Deposit(DepositRequestDto depositRequestDto)
        {
            var command = _mapper.Map<DepositCommand>(depositRequestDto);
            var result = await _mediator.Send(command);
            
            return result;
        }



        public Task<ServiceResponse<ExistingMoneyResponseDto>> ExistingMoney()
        {
            throw new NotImplementedException();
        }

        public Task GetAtmCassetteSettings()
        {
            throw new NotImplementedException();
        }

public async Task<ServiceResponse<WithdrawalResponseDto>> Withdrawal(WithdrawalRequestDto withdrawalRequestDto)
{
    var atm = await _atmRepository.GetAtmByIdAsync(withdrawalRequestDto.AtmId);
    if (atm == null) throw new Exception("ATM not found");

    if (!Enum.TryParse(withdrawalRequestDto.CurrencyType, out CurrencyType currencyType))
        throw new Exception("Invalid DenominationType requested");

    if (withdrawalRequestDto.Amount % 20 != 0 && withdrawalRequestDto.Amount % 50 != 0 &&
        withdrawalRequestDto.Amount % 100 != 0 && withdrawalRequestDto.Amount % 500 != 0)
    {
        throw new Exception("The amount cannot be provided with available banknotes.");
    }

    var availableCassettes = atm.Cassettes
        .Where(c => !c.IsDepositOnly && c.CurrencyDenominations.Any(d => d.CurrencyType == currencyType))
        .ToList();

    var sortedCassettes = availableCassettes
        .OrderByDescending(c => c.CurrencyDenominations.Max(d => (int)d.DenominationType))
        .ToList();

    decimal remainingAmount = withdrawalRequestDto.Amount;
    var withdrawalDetails = new List<WithdrawalDetailDto>();

    foreach (var cassette in sortedCassettes)
    {
        var denominations = cassette.CurrencyDenominations
            .Where(d => d.CurrencyType == currencyType)
            .OrderByDescending(d => (int)d.DenominationType)
            .ToList();

        foreach (var denomination in denominations)
        {
            var denominationValue = (int)denomination.DenominationType;
            int notesNeeded = (int)(remainingAmount / denominationValue);

            if (notesNeeded > 0)
            {
                int notesAvailable = cassette.CurrencyDenominations
                    .First(d => d.DenominationType == denomination.DenominationType).Quantity;
                int notesToWithdraw = Math.Min(notesNeeded, notesAvailable);

                if (notesToWithdraw > 0)
                {
                    cassette.CurrencyDenominations
                        .First(d => d.DenominationType == denomination.DenominationType).Quantity -= notesToWithdraw;
                    cassette.ExistQuantity -= notesToWithdraw * denominationValue;
                    remainingAmount -= notesToWithdraw * denominationValue;

                    withdrawalDetails.Add(new WithdrawalDetailDto
                    {
                        CassetteId = cassette.Id,
                        DenominationType = denominationValue,
                        CurrencyType = currencyType.ToString(),
                        WithdrawnQuantity = notesToWithdraw
                    });
                }
            }

            if (remainingAmount <= 0)
                break;
        }

        if (remainingAmount <= 0)
            break;
    }

    if (remainingAmount > 0)
        return new ServiceResponse<WithdrawalResponseDto>
        {
            Success = false,
            Message = $"Unable to fulfill the requested withdrawal amount. {remainingAmount} remaining."
        };

    // Veritabanına güncellemeyi kaydet
    await _atmRepository.UpdateAtmAsync(atm); // Değişiklikleri veritabanına kaydediyoruz.
    await _atmRepository.SaveChangesAsync();  // Bu adım, değişikliklerin kalıcı olarak kaydedilmesini sağlar.

    return new ServiceResponse<WithdrawalResponseDto>
    {
        Success = true,
        Data = new WithdrawalResponseDto
        {
            WithdrawalAmount = withdrawalRequestDto.Amount,
            Details = withdrawalDetails
        },
        Message = "Withdrawal completed successfully."
    };
}



        public Task<ServiceResponse<decimal>> GetAtmAmountById()
        {
            throw new NotImplementedException();
        }
    }
}