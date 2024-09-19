using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using CQRS_AtmProject.Application.Dtos.CurrencyDenominations;
using CQRS_AtmProject.Domain.Models;
using CQRS_AtmProject.Infrastructure.Data.Repositories.CurrencyDenominations;

namespace CQRS_AtmProject.Application.CurrencyDenominations.Command.Handlers
{
    public class UpdateCurrencyDenominationCommandHandler : IRequestHandler<UpdateCurrencyDenominationCommand, ServiceResponse<CurrencyDenominationDto>>
    {
        private readonly ICurrencyDenominationRepository _repository;
        private readonly IMapper _mapper;

        public UpdateCurrencyDenominationCommandHandler(ICurrencyDenominationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<CurrencyDenominationDto>> Handle(UpdateCurrencyDenominationCommand request, CancellationToken cancellationToken)
        {
            var currencyDenomination = await _repository.GetCurrencyDenominationByIdAsync(request.Id);
            if (currencyDenomination == null)
            {
                return new ServiceResponse<CurrencyDenominationDto>
                {
                    Success = false,
                    Data = null,
                    Message = $"Currency Denomination with Id {request.Id} not found."
                };
            }

            currencyDenomination.CurrencyType = request.CurrencyType;
            currencyDenomination.DenominationType = request.DenominationType;
            currencyDenomination.Quantity = request.Quantity;
            currencyDenomination.CassetteId = request.CassetteId;

            await _repository.UpdateCurrencyDenominationAsync(currencyDenomination);
            await _repository.SaveChangesAsync();

            var currencyDenominationDto = _mapper.Map<CurrencyDenominationDto>(currencyDenomination);

            return new ServiceResponse<CurrencyDenominationDto>
            {
                Success = true,
                Data = currencyDenominationDto,
                Message = "Currency Denomination updated successfully."
            };
        }
    }
}
