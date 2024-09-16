using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using UserProductManagementAPI.Application.Cassettes.Command;
using UserProductManagementAPI.Application.Cassettes.Query;
using UserProductManagementAPI.Application.Dtos.Cassettes;
using UserProductManagementAPI.Domain.Enums;
using UserProductManagementAPI.Domain.Models;
using UserProductManagementAPI.Infrastructure.Data.Repositories.Cassettes;

namespace UserProductManagementAPI.Infrastructure.Services
{
    public class CassetteService : ICassetteService
    {
        private readonly IMediator _mediator;
        private readonly ICassetteRepository _cassetteRepository;
        private readonly IMapper _mapper;

        public CassetteService(IMediator mediator, ICassetteRepository cassetteRepository, IMapper mapper)
        {
            _mediator = mediator;
            _cassetteRepository = cassetteRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<CassetteDto>>> GetAllCassettesAsync()
        {
            var query = new GetAllCassetteQuery();
            var cassettes = await _mediator.Send(query);
            return cassettes;
        }

        public async Task<ServiceResponse<CassetteDto>> GetCassetteByIdAsync(int id)
        {
            var query = new GetCassetteByIdQuery { Id = id };
            var cassette = await _mediator.Send(query);

            return cassette;
        }

        public async Task<ServiceResponse<CassetteDto>> CreateCassetteAsync(CreateCassetteDto createCassetteDto)
        {
            var command = _mapper.Map<CreateCassetteCommand>(createCassetteDto);
            var result = await _mediator.Send(command);

            return result;
        }

        public async Task<ServiceResponse<CassetteDto>> UpdateCassetteAsync(UpdateCassetteDto updateCassetteDto)
        {
            var command = _mapper.Map<UpdateCassetteCommand>(updateCassetteDto);
            var result = await _mediator.Send(command);

            return result;
        }

        public async Task<ServiceResponse<bool>> DeleteCassetteAsync(int id)
        {
            var command = new DeleteCassetteCommand { Id = id };
            var result = await _mediator.Send(command);

            return result;
        }


        public async Task<ServiceResponse<decimal>> GetCassetteAmountByCurrencyTypeAndId(int id, string currencyType)
        {
            var cassette = await _cassetteRepository.GetCassetteByIdAsync(id);
            if (cassette == null)
            {
                throw new ArgumentException("Cassette not found");
            }

            if (!Enum.TryParse<CurrencyType>(currencyType, true, out var parsedCurrencyType))
            {
                throw new ArgumentException("Invalid currency type");
            }

            var totalAmount = cassette.CurrencyDenominations
                                    .Where(c => c.CurrencyType == parsedCurrencyType)
                                    .Sum(c => c.Quantity * (int)c.DenominationType);

            return new ServiceResponse<decimal>
            {
                Success = true,
                Data = totalAmount,
                Message = "Cassette amount calculated for specific currency type."
            };
        }
    }
}
