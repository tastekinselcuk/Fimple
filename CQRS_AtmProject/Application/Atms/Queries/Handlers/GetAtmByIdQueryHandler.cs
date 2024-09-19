using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using CQRS_AtmProject.Application.Dtos.Atms;
using CQRS_AtmProject.Domain.Models;
using CQRS_AtmProject.Infrastructure.Data.Repositories.Atms;

namespace CQRS_AtmProject.Application.Atms.Queries.Handlers
{
    public class GetAtmByIdQueryHandler : IRequestHandler<GetAtmByIdQuery, ServiceResponse<AtmDto>>
    {
        private readonly IAtmRepository _atmRepository;
        private readonly IMapper _mapper;

        public GetAtmByIdQueryHandler(IAtmRepository atmRepository, IMapper mapper)
        {
            _atmRepository = atmRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<AtmDto>> Handle(GetAtmByIdQuery request, CancellationToken cancellationToken)
        {
            var atm = await _atmRepository.GetAtmByIdAsync(request.Id);
            await _atmRepository.SaveChangesAsync();
            if (atm == null)
            {
                return new ServiceResponse<AtmDto>
                {
                    Success = false,
                    Data = null,
                    Message = $"ATM with ID {request.Id} not found."
                };
            }

            var atmDto = _mapper.Map<AtmDto>(atm);
            return new ServiceResponse<AtmDto>
            {
                Success = true,
                Data = atmDto,
                Message = "ATM retrieved successfully."
            };
        }
    }
}
