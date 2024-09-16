using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using UserProductManagementAPI.Application.Dtos.Atms;
using UserProductManagementAPI.Domain.Models;
using UserProductManagementAPI.Infrastructure.Data.Repositories.Atms;

namespace UserProductManagementAPI.Application.Atms.Commands.Handlers
{
    public class UpdateAtmCommandHandler : IRequestHandler<UpdateAtmCommand, ServiceResponse<AtmDto>>
    {
        private readonly IAtmRepository _atmRepository;
        private readonly IMapper _mapper;

        public UpdateAtmCommandHandler(IAtmRepository atmRepository, IMapper mapper)
        {
            _atmRepository = atmRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<AtmDto>> Handle(UpdateAtmCommand request, CancellationToken cancellationToken)
        {
            var atm = await _atmRepository.GetAtmByIdAsync(request.Id);
            if (atm == null)
            {
                return new ServiceResponse<AtmDto>
                {
                    Success = false,
                    Data = null,
                    Message = $"ATM with Id {request.Id} not found."
                };
            }


            await _atmRepository.UpdateAtmAsync(atm);
            await _atmRepository.SaveChangesAsync();

            var atmDto = _mapper.Map<AtmDto>(atm);

            return new ServiceResponse<AtmDto>
            {
                Success = true,
                Data = atmDto,
                Message = "ATM updated successfully."
            };
        }
    }
}
