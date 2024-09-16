using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using UserProductManagementAPI.Application.Dtos.Atms;
using UserProductManagementAPI.Domain.Models;
using UserProductManagementAPI.Infrastructure.Data.Repositories.Atms;

namespace UserProductManagementAPI.Application.Atms.Commands.Handlers
{
    public class CreateAtmCommandHandler : IRequestHandler<CreateAtmCommand, ServiceResponse<AtmDto>>
    {
        private readonly IAtmRepository _atmRepository;
        private readonly IMapper _mapper;

        public CreateAtmCommandHandler(IAtmRepository atmRepository, IMapper mapper)
        {
            _atmRepository = atmRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<AtmDto>> Handle(CreateAtmCommand request, CancellationToken cancellationToken)
        {
            var atm = new Atm
            {
                DepositOnlyCount = request.DepositOnlyCount,
                ForeignCurrencyOnlyCount = request.ForeignCurrencyOnlyCount,
                TotalCassette = request.TotalCassette
            };

            await _atmRepository.AddAtmAsync(atm);
            await _atmRepository.SaveChangesAsync();

            var atmDto = _mapper.Map<AtmDto>(atm);

            return new ServiceResponse<AtmDto>
            {
                Success = true,
                Data = atmDto,
                Message = "ATM created successfully."
            };
        }
    }
}
