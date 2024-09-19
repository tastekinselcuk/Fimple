using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using CQRS_AtmProject.Application.Dtos;
using CQRS_AtmProject.Application.Dtos.Atms;
using CQRS_AtmProject.Application.Dtos.CurrencyDenominations;
using CQRS_AtmProject.Domain.Enums;
using CQRS_AtmProject.Domain.Models;
using CQRS_AtmProject.Infrastructure.Data.Repositories.Atms;
using CQRS_AtmProject.Infrastructure.Data.Repositories.CurrencyDenominations;

namespace CQRS_AtmProject.Application.Transactions.Commands.Handlers
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

            // DenominationType doğrulaması
            if (!Enum.TryParse(request.DenominationType, out DenominationType denominationType) || 
                !Enum.IsDefined(typeof(DenominationType), denominationType))
            {
                return new ServiceResponse<DepositResponseDto>
                {
                    Success = false,
                    Message = "Invalid DenominationType provided"
                };
            }

            // CurrencyType doğrulaması
            if (!Enum.TryParse(request.CurrencyType, out CurrencyType currencyType) || 
                !Enum.IsDefined(typeof(CurrencyType), currencyType))
            {
                return new ServiceResponse<DepositResponseDto>
                {
                    Success = false,
                    Message = "Invalid CurrencyType provided"
                };
            }

            // Quantity'nin geçerli olup olmadığını kontrol ettik
            if (request.Quantity <= 0)
                return new ServiceResponse<DepositResponseDto>
                {
                    Success = false,
                    Message = "The quantity must be greater than 0."
                };

            // Para yatırmak için uygun kasetleri filtreledik
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

            // Kasetin mevcut miktarını güncelle
            cassette.ExistQuantity += request.Quantity;

            // CurrencyDenomination'u güncelle
            var currencyDenomination = cassette.CurrencyDenominations?
                .FirstOrDefault(d => d.DenominationType == denominationType && d.CurrencyType == currencyType);

            if (currencyDenomination != null)
            {
                currencyDenomination.Quantity += request.Quantity;
                await _currencyDenominationRepository.UpdateCurrencyDenominationAsync(currencyDenomination);
            }

            await _atmRepository.UpdateAtmAsync(atm);
            await _currencyDenominationRepository.UpdateCurrencyDenominationAsync(currencyDenomination);

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
