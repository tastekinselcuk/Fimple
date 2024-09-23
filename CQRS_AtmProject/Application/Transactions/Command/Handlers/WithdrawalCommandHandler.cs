using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CQRS_AtmProject.Application.Dtos;
using CQRS_AtmProject.Application.Dtos.Atms;
using CQRS_AtmProject.Application.Dtos.CurrencyDenominations;
using CQRS_AtmProject.Domain.Enums;
using CQRS_AtmProject.Domain.Models;
using CQRS_AtmProject.Infrastructure.Data.Repositories.Atms;
using CQRS_AtmProject.Infrastructure.Data.Repositories.CurrencyDenominations;
using MediatR;

namespace CQRS_AtmProject.Application.Transactions.Command.Handlers
{
    public class WithdrawalCommandHandler : IRequestHandler<WithdrawalCommand, ServiceResponse<WithdrawalResponseDto>>
    {
        private readonly IAtmRepository _atmRepository;
        private readonly ICurrencyDenominationRepository _currencyDenominationRepository;
        private readonly IMapper _mapper;

        public WithdrawalCommandHandler(IAtmRepository atmRepository, ICurrencyDenominationRepository currencyDenominationRepository, IMapper mapper)
        {
            _atmRepository = atmRepository;
            _currencyDenominationRepository = currencyDenominationRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<WithdrawalResponseDto>> Handle(WithdrawalCommand request, CancellationToken cancellationToken)
        {
            var atm = await _atmRepository.GetAtmByIdAsync(request.AtmId);
            if (atm == null)
                return new ServiceResponse<WithdrawalResponseDto>
                {
                    Success = false,
                    Message = "ATM not found"
                };

            // CurrencyType doğrulaması
            if (!Enum.TryParse(request.CurrencyType, out CurrencyType currencyType) || 
                !Enum.IsDefined(typeof(CurrencyType), currencyType))
            {
                return new ServiceResponse<WithdrawalResponseDto>
                {
                    Success = false,
                    Message = "Invalid CurrencyType provided"
                };
            }

            // Miktarın 20, 50, 100 veya 500'lük banknotlara tam bölünüp bölünmediğini ve > 0'ı kontrol ettik
            if (request.Amount % 20 != 0 && request.Amount % 50 != 0 &&
                request.Amount % 100 != 0 && request.Amount % 500 != 0)
                return new ServiceResponse<WithdrawalResponseDto>
                {
                    Success = false,
                    Message = "The requested amount must be in multiples of 20, 50, 100, or 500. Please enter a valid amount."
                };

            if (request.Amount <= 0)
                return new ServiceResponse<WithdrawalResponseDto>
                {
                    Success = false,
                    Message = "The amount must be greater than 0."
                };

            // Para çekimi için uygun kasetleri filtreledik
            var availableCassettes = atm.Cassettes
                .Where(c => !c.IsDepositOnly && c.CurrencyDenominations.Any(d => d.CurrencyType == currencyType))
                .ToList();

            // Kasetleri en büyük banknottan küçüğe doğru sıraladık
            var sortedCassettes = availableCassettes
                .OrderByDescending(c => c.CurrencyDenominations?.Max(d => (int)d.DenominationType))
                .ToList();

            decimal remainingAmount = request.Amount; // Çekilecek kalan miktar
            var withdrawalDetails = new List<WithdrawalDetailDto>(); // Para çekme detaylarını tutacak liste

            // Her kaset için işlem yap
            foreach (var cassette in sortedCassettes)
            {
                // Kasetteki istenen para birimindeki banknotları sırala
                var denominations = cassette.CurrencyDenominations?
                    .Where(d => d.CurrencyType == currencyType)
                    .OrderByDescending(d => (int)d.DenominationType)
                    .ToList();

                // Her banknot türü için işlem yap
                foreach (var denomination in denominations)
                {
                    var denominationValue = (int)denomination.DenominationType;
                    int notesNeeded = (int)(remainingAmount / denominationValue); // Kaç tane banknota ihtiyaç var

                    // Gerekli banknot sayısı varsa
                    if (notesNeeded > 0)
                    {
                        int notesAvailable = denomination.Quantity;
                        int notesToWithdraw = Math.Min(notesNeeded, notesAvailable); // Çekilecek banknot sayısını belirle

                        // Çekilecek banknot sayısı varsa güncelle
                        if (notesToWithdraw > 0)
                        {
                            denomination.Quantity -= notesToWithdraw;
                            cassette.ExistQuantity -= notesToWithdraw;
                            remainingAmount -= notesToWithdraw * denominationValue;

                            // Çekim detaylarını listeye ekle
                            withdrawalDetails.Add(new WithdrawalDetailDto
                            {
                                CassetteId = cassette.Id,
                                DenominationType = denominationValue,
                                CurrencyType = currencyType.ToString(),
                                WithdrawnQuantity = notesToWithdraw
                            });
                        }
                    }

                    // Çekilecek kalan miktar 0 veya altına inerse döngüden çık
                    if (remainingAmount <= 0)
                        break;
                }

                if (remainingAmount <= 0)
                    break;
            }

            // Eğer hala çekilemeyen miktar kaldıysa, işlemi başarısız olarak bildir
            if (remainingAmount > 0)
                return new ServiceResponse<WithdrawalResponseDto>
                {
                    Success = false,
                    Message = $"Unable to fulfill the requested withdrawal amount. {remainingAmount} remaining."
                };

            await _atmRepository.UpdateAtmAsync(atm);
            await _atmRepository.SaveChangesAsync();

            return new ServiceResponse<WithdrawalResponseDto>
            {
                Success = true,
                Data = new WithdrawalResponseDto
                {
                    WithdrawalAmount = request.Amount,
                    Details = withdrawalDetails
                },
                Message = "Withdrawal completed successfully."
            };
        }
    }
}
