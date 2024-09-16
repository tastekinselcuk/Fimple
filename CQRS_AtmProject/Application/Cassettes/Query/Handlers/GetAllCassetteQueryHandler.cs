using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using UserProductManagementAPI.Application.Dtos.Cassettes;
using UserProductManagementAPI.Domain.Models;
using UserProductManagementAPI.Infrastructure.Data.Repositories.Cassettes;

namespace UserProductManagementAPI.Application.Cassettes.Query.Handlers
{
    public class GetAllCassetteQueryHandler : IRequestHandler<GetAllCassetteQuery, ServiceResponse<List<CassetteDto>>>
    {
        private readonly ICassetteRepository _cassetteRepository;
        private readonly IMapper _mapper;

        public GetAllCassetteQueryHandler(ICassetteRepository cassetteRepository, IMapper mapper)
        {
            _cassetteRepository = cassetteRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<CassetteDto>>> Handle(GetAllCassetteQuery request, CancellationToken cancellationToken)
        {
            var cassettes = await _cassetteRepository.GetAllCassettesAsync();
            await _cassetteRepository.SaveChangesAsync();
            var cassetteDtos = _mapper.Map<List<CassetteDto>>(cassettes);

            return new ServiceResponse<List<CassetteDto>>
            {
                Data = cassetteDtos,
                Success = true,
                Message = "All Cassettes retrieved successfully."
            };
        }
    }
}
