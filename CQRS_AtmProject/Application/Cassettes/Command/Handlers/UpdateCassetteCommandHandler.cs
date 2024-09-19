using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using CQRS_AtmProject.Application.Dtos.Cassettes;
using CQRS_AtmProject.Domain.Models;
using CQRS_AtmProject.Infrastructure.Data.Repositories.Cassettes;

namespace CQRS_AtmProject.Application.Cassettes.Command.Handlers
{
    public class UpdateCassetteCommandHandler : IRequestHandler<UpdateCassetteCommand, ServiceResponse<CassetteDto>>
    {
        private readonly ICassetteRepository _cassetteRepository;
        private readonly IMapper _mapper;

        public UpdateCassetteCommandHandler(ICassetteRepository cassetteRepository, IMapper mapper)
        {
            _cassetteRepository = cassetteRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<CassetteDto>> Handle(UpdateCassetteCommand request, CancellationToken cancellationToken)
        {
            var cassette = await _cassetteRepository.GetCassetteByIdAsync(request.Id);
            if (cassette == null)
            {
                return new ServiceResponse<CassetteDto>
                {
                    Success = false,
                    Data = null,
                    Message = $"Cassette with Id {request.Id} not found."
                };
            }

            // Update cassette properties
            cassette.QuantityCapacity = request.QuantityCapacity;
            cassette.IsDepositOnly = request.IsDepositOnly;
            cassette.IsForeignCurrencyOnly = request.IsForeignCurrencyOnly;
            cassette.AtmId = request.AtmId;

            await _cassetteRepository.UpdateCassetteAsync(cassette);
            await _cassetteRepository.SaveChangesAsync();

            var cassetteDto = _mapper.Map<CassetteDto>(cassette);

            return new ServiceResponse<CassetteDto>
            {
                Success = true,
                Data = cassetteDto,
                Message = "Cassette updated successfully."
            };
        }
    }
}
