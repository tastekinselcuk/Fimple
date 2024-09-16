using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using UserProductManagementAPI.Application.Dtos;
using UserProductManagementAPI.Application.Dtos.Atms;
using UserProductManagementAPI.Application.Dtos.CurrencyDenominations;
using UserProductManagementAPI.Domain.Enums;
using UserProductManagementAPI.Domain.Models;
using UserProductManagementAPI.Infrastructure.Data.Repositories.Atms;
using UserProductManagementAPI.Infrastructure.Data.Repositories.CurrencyDenominations;

namespace UserProductManagementAPI.Application.Atms.Commands.Handlers
{
    public class DepositCommandHandler : IRequestHandler<DepositCommand, ServiceResponse<DepositResponseDto>>
    {
        private readonly IAtmRepository _atmRepository;
        private readonly ICurrencyDenominationRepository _currencyDenominationRepository;
        private readonly IMapper _mapper;

        public DepositCommandHandler(IAtmRepository atmRepository, ICurrencyDenominationRepository currencyDenominationRepository, IMapper mapper)
        {
            _atmRepository = atmRepository;
            _currencyDenominationRepository = currencyDenominationRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<DepositResponseDto>> Handle(DepositCommand request, CancellationToken cancellationToken)
        {
            var atm = await _atmRepository.GetAtmByIdAsync(request.AtmId);
            if (atm == null) 
                return new ServiceResponse<DepositResponseDto>
                {
                    Success = false,
                    Message = "ATM not found"
                };

            if (!Enum.TryParse(request.DenominationType, out DenominationType denominationType))
                return new ServiceResponse<DepositResponseDto>
                {
                    Success = false,
                    Message = "Invalid DenominationType provided"
                };

            if (!Enum.TryParse(request.CurrencyType, out CurrencyType currencyType))
                return new ServiceResponse<DepositResponseDto>
                {
                    Success = false,
                    Message = "Invalid CurrencyType provided"
                };

            var cassette = atm.Cassettes?
                .FirstOrDefault(c => c.ExistQuantity + request.Quantity <= c.QuantityCapacity &&
                    (!c.IsForeignCurrencyOnly || (currencyType == CurrencyType.USD ||
                    currencyType == CurrencyType.EUR)) &&
                (c.CurrencyDenominations != null &&
                c.CurrencyDenominations.Any(d =>
                    d.DenominationType == denominationType &&
                    d.CurrencyType == currencyType)));

            if (cassette == null)
                return new ServiceResponse<DepositResponseDto>
                {
                    Success = false,
                    Message = "Unable to provide deposit service at this time. Please try again later."
                };

            cassette.ExistQuantity += request.Quantity;

            var currencyDenomination = cassette.CurrencyDenominations
                .FirstOrDefault(d => d.DenominationType == denominationType && d.CurrencyType == currencyType);

            if (currencyDenomination != null)
            {
                currencyDenomination.Quantity += request.Quantity;
                _currencyDenominationRepository.UpdateCurrencyDenominationAsync(currencyDenomination);
            }

            _atmRepository.UpdateAtmAsync(atm);
            _currencyDenominationRepository.UpdateCurrencyDenominationAsync(currencyDenomination);

            await _atmRepository.SaveChangesAsync();
            await _currencyDenominationRepository.SaveChangesAsync();

            var depositResponseDto = new DepositResponseDto
            {
                CassetteId = cassette.Id,
                DepositedAmount = request.Quantity,
                RemainingCapacity = cassette.QuantityCapacity - cassette.ExistQuantity,
            };

            return new ServiceResponse<DepositResponseDto>
            {
                Success = true,
                Data = depositResponseDto,
                Message = "Deposit operation completed successfully."
            };
        }
    }
}
