using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using CQRS_AtmProject.Application.Dtos.Atms;
using CQRS_AtmProject.Domain.Models;
using CQRS_AtmProject.Infrastructure.Data.Repositories.Atms;

namespace CQRS_AtmProject.Application.Atms.Queries.Handlers
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
