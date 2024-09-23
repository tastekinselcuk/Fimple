using AutoMapper;
using CQRS_AtmProject.Application.Atms.Commands;
using CQRS_AtmProject.Application.Dtos;
using CQRS_AtmProject.Application.Dtos.Atms;
using CQRS_AtmProject.Application.Dtos.Cassettes;
using CQRS_AtmProject.Application.Dtos.CurrencyDenominations;
using CQRS_AtmProject.Application.Dtos.ExistingMoney;
using CQRS_AtmProject.Application.Transactions.Command;
using CQRS_AtmProject.Application.Transactions.Commands;
using CQRS_AtmProject.Domain.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Atm mappings
        CreateMap<Atm, AtmDto>();
        CreateMap<AtmDto, Atm>();
        
        // Cassette mappings
        CreateMap<CassetteDto, Cassette>();
        CreateMap<Cassette, CassetteDto>();

        // CurrencyDenomination mappings
        CreateMap<CurrencyDenomination, CurrencyDenominationDto>();
        CreateMap<CurrencyDenominationDto, CurrencyDenomination>();

        //Deposit mappings
        CreateMap<DepositRequestDto, DepositCommand>();
        CreateMap<DepositCommand, DepositRequestDto>();

        //Withdraw mappings
        CreateMap<WithdrawalRequestDto, WithdrawalCommand>();
        CreateMap<WithdrawalCommand, WithdrawalRequestDto>();

        //Transaction mappings
        CreateMap<ExistingMoneyResponseDto, CurrencyDenomination>();
        CreateMap<CurrencyDenomination, ExistingMoneyResponseDto>();

    }
}
