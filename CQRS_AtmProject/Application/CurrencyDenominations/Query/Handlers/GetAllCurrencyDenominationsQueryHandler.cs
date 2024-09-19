using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using CQRS_AtmProject.Application.Dtos.CurrencyDenominations;
using CQRS_AtmProject.Domain.Models;
using CQRS_AtmProject.Infrastructure.Data.Repositories.CurrencyDenominations;

namespace CQRS_AtmProject.Application.CurrencyDenominations.Query.Handlers
{
    public class GetAllCurrencyDenominationsQueryHandler : IRequestHandler<GetAllCurrencyDenominationsQuery, ServiceResponse<List<CurrencyDenominationDto>>>
    {
        private readonly ICurrencyDenominationRepository _repository;
        private readonly IMapper _mapper;

        public GetAllCurrencyDenominationsQueryHandler(ICurrencyDenominationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<CurrencyDenominationDto>>> Handle(GetAllCurrencyDenominationsQuery request, CancellationToken cancellationToken)
        {
            var currencyDenominations = await _repository.GetAllCurrencyDenominationsAsync();
            await _repository.SaveChangesAsync();
            var currencyDenominationDtos = _mapper.Map<List<CurrencyDenominationDto>>(currencyDenominations);

            return new ServiceResponse<List<CurrencyDenominationDto>>
            {
                Data = currencyDenominationDtos,
                Success = true,
                Message = "All Currency Denominations retrieved successfully."
            };
        }
    }
}
