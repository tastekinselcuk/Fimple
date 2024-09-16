using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using UserProductManagementAPI.Application.Dtos.Atms;
using UserProductManagementAPI.Domain.Models;
using UserProductManagementAPI.Infrastructure.Data.Repositories.Atms;

namespace UserProductManagementAPI.Application.Atms.Queries.Handlers
{
    public class GetAllAtmQueryHandler : IRequestHandler<GetAllAtmsQuery, ServiceResponse<List<AtmDto>>>
    {
        private readonly IAtmRepository _atmRepository;
        private readonly IMapper _mapper;

        public GetAllAtmQueryHandler(IAtmRepository atmRepository, IMapper mapper)
        {
            _atmRepository = atmRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<AtmDto>>> Handle(GetAllAtmsQuery request, CancellationToken cancellationToken)
        {
            var atms = await _atmRepository.GetAllAtmsAsync();
            await _atmRepository.SaveChangesAsync();
            var atmDtos = _mapper.Map<List<AtmDto>>(atms);

            return new ServiceResponse<List<AtmDto>>
            {
                Data = atmDtos,
                Success = true,
                Message = "All ATMs retrieved successfully."
            };
        }
    }
}
