using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using CQRS_AtmProject.Application.CurrencyDenominations.Command;
using CQRS_AtmProject.Application.CurrencyDenominations.Query;
using CQRS_AtmProject.Application.Dtos.CurrencyDenominations;
using CQRS_AtmProject.Domain.Enums;
using CQRS_AtmProject.Domain.Models;

namespace CQRS_AtmProject.Infrastructure.Services
{
    public class CurrencyDenominationService : ICurrencyDenominationService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CurrencyDenominationService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<CurrencyDenominationDto>> CreateCurrencyDenominationAsync(CurrencyDenominationDto dto)
        {
            // Convert string to enum
            if (!Enum.TryParse(dto.DenominationType, true, out DenominationType denominationType))
            {
                return new ServiceResponse<CurrencyDenominationDto>
                {
                    Success = false,
                    Message = "Invalid DenominationType provided"
                };
            }

            if (!Enum.TryParse(dto.CurrencyType, true, out CurrencyType currencyType))
            {
                return new ServiceResponse<CurrencyDenominationDto>
                {
                    Success = false,
                    Message = "Invalid CurrencyType provided"
                };
            }

            var command = new CreateCurrencyDenominationCommand
            {
                DenominationType = denominationType,
                CurrencyType = currencyType,
                Quantity = dto.Quantity
            };

            var result = await _mediator.Send(command);
            return result;
        }

        public async Task<ServiceResponse<CurrencyDenominationDto>> UpdateCurrencyDenominationAsync(int id, CurrencyDenominationDto updateDto)
        {
            if (!Enum.TryParse(updateDto.DenominationType, true, out DenominationType denominationType))
            {
                return new ServiceResponse<CurrencyDenominationDto>
                {
                    Success = false,
                    Message = "Invalid DenominationType provided"
                };
            }

            if (!Enum.TryParse(updateDto.CurrencyType, true, out CurrencyType currencyType))
            {
                return new ServiceResponse<CurrencyDenominationDto>
                {
                    Success = false,
                    Message = "Invalid CurrencyType provided"
                };
            }

            var command = new UpdateCurrencyDenominationCommand
            {
                Id = id,
                DenominationType = denominationType,
                CurrencyType = currencyType,
                Quantity = updateDto.Quantity
            };

            var result = await _mediator.Send(command);
            return result;
        }

        public async Task<ServiceResponse<bool>> DeleteCurrencyDenominationAsync(int id)
        {
            var command = new DeleteCurrencyDenominationCommand { Id = id };
            var result = await _mediator.Send(command);
            return result;
        }

        public async Task<ServiceResponse<CurrencyDenominationDto>> GetCurrencyDenominationByIdAsync(int id)
        {
            var query = new GetCurrencyDenominationByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            return result;
        }

        public async Task<ServiceResponse<List<CurrencyDenominationDto>>> GetAllCurrencyDenominationsAsync()
        {
            var query = new GetAllCurrencyDenominationsQuery();
            var result = await _mediator.Send(query);
            return result;
        }


    }
}
