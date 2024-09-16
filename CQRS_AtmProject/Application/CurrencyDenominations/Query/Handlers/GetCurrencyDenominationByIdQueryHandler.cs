using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using UserProductManagementAPI.Application.Dtos.CurrencyDenominations;
using UserProductManagementAPI.Domain.Models;
using UserProductManagementAPI.Infrastructure.Data.Repositories.CurrencyDenominations;

namespace UserProductManagementAPI.Application.CurrencyDenominations.Query.Handlers
{
    public class GetCurrencyDenominationByIdQueryHandler : IRequestHandler<GetCurrencyDenominationByIdQuery, ServiceResponse<CurrencyDenominationDto>>
    {
        private readonly ICurrencyDenominationRepository _repository;
        private readonly IMapper _mapper;

        public GetCurrencyDenominationByIdQueryHandler(ICurrencyDenominationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<CurrencyDenominationDto>> Handle(GetCurrencyDenominationByIdQuery request, CancellationToken cancellationToken)
        {
            var currencyDenomination = await _repository.GetCurrencyDenominationByIdAsync(request.Id);
            await _repository.SaveChangesAsync();
            if (currencyDenomination == null)
            {
                return new ServiceResponse<CurrencyDenominationDto>
                {
                    Success = false,
                    Data = null,
                    Message = $"Currency Denomination with ID {request.Id} not found."
                };
            }

            var currencyDenominationDto = _mapper.Map<CurrencyDenominationDto>(currencyDenomination);
            return new ServiceResponse<CurrencyDenominationDto>
            {
                Success = true,
                Data = currencyDenominationDto,
                Message = "Currency Denomination retrieved successfully."
            };
        }
    }
}
