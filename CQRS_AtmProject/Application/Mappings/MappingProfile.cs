using AutoMapper;
using CQRS_AtmProject.Application.Atms.Commands;
using CQRS_AtmProject.Application.Dtos;
using CQRS_AtmProject.Application.Dtos.Atms;
using CQRS_AtmProject.Application.Dtos.Cassettes;
using CQRS_AtmProject.Application.Dtos.CurrencyDenominations;
using CQRS_AtmProject.Application.Transactions.Command;
using CQRS_AtmProject.Application.Transactions.Commands;
using CQRS_AtmProject.Domain.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Atm mappings
        CreateMap<CreateAtmDto, Atm>();
        CreateMap<Atm, AtmDto>();
        CreateMap<UpdateAtmDto, Atm>();
        
        // Cassette mappings
        CreateMap<CreateCassetteDto, Cassette>();
        CreateMap<Cassette, CassetteDto>();
        CreateMap<UpdateCassetteDto, Cassette>();

        // CurrencyDenomination mappings
        CreateMap<CreateCurrencyDenominationDto, CurrencyDenomination>();
        CreateMap<CurrencyDenomination, CurrencyDenominationDto>();
        CreateMap<UpdateCurrencyDenominationDto, CurrencyDenomination>();

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
