using AutoMapper;
using UserProductManagementAPI.Application.Atms.Commands;
using UserProductManagementAPI.Application.Dtos;
using UserProductManagementAPI.Application.Dtos.Atms;
using UserProductManagementAPI.Application.Dtos.Cassettes;
using UserProductManagementAPI.Application.Dtos.CurrencyDenominations;
using UserProductManagementAPI.Domain.Models;

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

    }
}
