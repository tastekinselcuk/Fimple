using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using UserProductManagementAPI.Application.Dtos.CurrencyDenominations;
using UserProductManagementAPI.Domain.Models;
using UserProductManagementAPI.Infrastructure.Data.Repositories.CurrencyDenominations;

namespace UserProductManagementAPI.Application.CurrencyDenominations.Command.Handlers
{
    public class CreateCurrencyDenominationCommandHandler : IRequestHandler<CreateCurrencyDenominationCommand, ServiceResponse<CurrencyDenominationDto>>
    {
        private readonly ICurrencyDenominationRepository _repository;
        private readonly IMapper _mapper;

        public CreateCurrencyDenominationCommandHandler(ICurrencyDenominationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<CurrencyDenominationDto>> Handle(CreateCurrencyDenominationCommand request, CancellationToken cancellationToken)
        {
            var currencyDenomination = new CurrencyDenomination
            {
                CurrencyType = request.CurrencyType,
                DenominationType = request.DenominationType,
                Quantity = request.Quantity,
                CassetteId = request.CassetteId
            };

            await _repository.AddCurrencyDenominationAsync(currencyDenomination);
            await _repository.SaveChangesAsync();

            var currencyDenominationDto = _mapper.Map<CurrencyDenominationDto>(currencyDenomination);

            return new ServiceResponse<CurrencyDenominationDto>
            {
                Success = true,
                Data = currencyDenominationDto,
                Message = "Currency Denomination created successfully."
            };
        }
    }
}
