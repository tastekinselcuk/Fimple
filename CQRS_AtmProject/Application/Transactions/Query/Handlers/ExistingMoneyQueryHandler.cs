using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CQRS_AtmProject.Application.Dtos;
using CQRS_AtmProject.Application.Dtos.Cassettes;
using CQRS_AtmProject.Application.Dtos.CurrencyDenominations;
using CQRS_AtmProject.Domain.Models;
using CQRS_AtmProject.Infrastructure.Data.Repositories.Cassettes;
using CQRS_AtmProject.Infrastructure.Data.Repositories.CurrencyDenominations;
using CQRS_AtmProject.Infrastructure.ExceptionHandling;
using MediatR;

namespace CQRS_AtmProject.Application.Transactions.Query.Handlers
{
    public class ExistingMoneyQueryHandler : IRequestHandler<ExistingMoneyQuery, ServiceResponse<List<CurrencyDenominationDto>>>
    {
        private readonly ICurrencyDenominationRepository _currencyDenominationRepository;
        private readonly IMapper _mapper;

        public ExistingMoneyQueryHandler(ICurrencyDenominationRepository currencyDenominationRepository, IMapper mapper)
        {
            _currencyDenominationRepository = currencyDenominationRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<CurrencyDenominationDto>>> Handle(ExistingMoneyQuery request, CancellationToken cancellationToken)
        {
            // Kaset ID'sine göre döviz birimlerini al
            var currencyDenominations = await _currencyDenominationRepository.GetCurrencyDenominationsByCassetteIdAsync(request.CassetteId);
            await _currencyDenominationRepository.SaveChangesAsync();
            if (currencyDenominations == null || currencyDenominations.Count == 0)
                throw new NotFoundException("Currency denominations not found for the specified cassette.");

            // Döviz birimlerini DTO'lara dönüştür
            var existingMoney = _mapper.Map<List<CurrencyDenominationDto>>(currencyDenominations);

            return new ServiceResponse<List<CurrencyDenominationDto>>
            {
                Success = true,
                Data = existingMoney,
                Message = "Currency denominations retrieved successfully."
            };
        }
    }
}
