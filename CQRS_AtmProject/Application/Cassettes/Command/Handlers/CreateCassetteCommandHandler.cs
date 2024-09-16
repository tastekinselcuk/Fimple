using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using UserProductManagementAPI.Application.Dtos.Cassettes;
using UserProductManagementAPI.Domain.Models;
using UserProductManagementAPI.Infrastructure.Data.Repositories.Cassettes;

namespace UserProductManagementAPI.Application.Cassettes.Command.Handlers
{
    public class CreateCassetteCommandHandler : IRequestHandler<CreateCassetteCommand, ServiceResponse<CassetteDto>>
    {
        private readonly ICassetteRepository _cassetteRepository;
        private readonly IMapper _mapper;

        public CreateCassetteCommandHandler(ICassetteRepository cassetteRepository, IMapper mapper)
        {
            _cassetteRepository = cassetteRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<CassetteDto>> Handle(CreateCassetteCommand request, CancellationToken cancellationToken)
        {
            var cassette = new Cassette
            {
                AtmId = request.AtmId,
                QuantityCapacity = request.QuantityCapacity,
                ExistQuantity = request.ExistQuantity,
                IsDepositOnly = request.IsDepositOnly,
                IsForeignCurrencyOnly = request.IsForeignCurrencyOnly,
            };

            await _cassetteRepository.AddCassetteAsync(cassette);
            await _cassetteRepository.SaveChangesAsync();

            var cassetteDto = _mapper.Map<CassetteDto>(cassette);

            return new ServiceResponse<CassetteDto>
            {
                Success = true,
                Data = cassetteDto,
                Message = "Cassette created successfully."
            };
        }
    }
}
