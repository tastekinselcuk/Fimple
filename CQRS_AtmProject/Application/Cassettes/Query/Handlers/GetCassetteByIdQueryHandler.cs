using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using CQRS_AtmProject.Application.Dtos.Cassettes;
using CQRS_AtmProject.Domain.Models;
using CQRS_AtmProject.Infrastructure.Data.Repositories.Cassettes;

namespace CQRS_AtmProject.Application.Cassettes.Query.Handlers
{
    public class GetCassetteByIdQueryHandler : IRequestHandler<GetCassetteByIdQuery, ServiceResponse<CassetteDto>>
    {
        private readonly ICassetteRepository _cassetteRepository;
        private readonly IMapper _mapper;

        public GetCassetteByIdQueryHandler(ICassetteRepository cassetteRepository, IMapper mapper)
        {
            _cassetteRepository = cassetteRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<CassetteDto>> Handle(GetCassetteByIdQuery request, CancellationToken cancellationToken)
        {
            var cassette = await _cassetteRepository.GetCassetteByIdAsync(request.Id);
            await _cassetteRepository.SaveChangesAsync();
            if (cassette == null)
            {
                return new ServiceResponse<CassetteDto>
                {
                    Success = false,
                    Data = null,
                    Message = $"Cassette with ID {request.Id} not found."
                };
            }

            var cassetteDto = _mapper.Map<CassetteDto>(cassette);
            return new ServiceResponse<CassetteDto>
            {
                Success = true,
                Data = cassetteDto,
                Message = "Cassette retrieved successfully."
            };
        }
    }
}
