using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using CQRS_AtmProject.Application.Dtos.Atms;
using CQRS_AtmProject.Domain.Models;
using CQRS_AtmProject.Infrastructure.Data.Repositories.Atms;
using CQRS_AtmProject.Application.Dtos;
using CQRS_AtmProject.Infrastructure.Services;
using CQRS_AtmProject.Application.Dtos.ExistingMoney;

namespace CQRS_AtmProject.Application.Atms.Queries.Handlers
{
public class ExistingMoneyQueryHandler : IRequestHandler<ExistingMoneyQuery, ServiceResponse<MoneyTotalsDto>>
{
    private readonly ITransactionService _transactionService;

    public ExistingMoneyQueryHandler(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public async Task<ServiceResponse<MoneyTotalsDto>> Handle(ExistingMoneyQuery request, CancellationToken cancellationToken)
    {
        // Öncelikle mevcut ATM paralarını getiren servisi çağır
        var response = await _transactionService.DetailedExistingMoneyasync(request.AtmId);

        if (!response.Success || response.Data == null)
        {
            return new ServiceResponse<MoneyTotalsDto>
            {
                Success = false,
                Data = null,
                Message = response.Message
            };
        }

        // Şimdi USD, EUR ve TRY için toplam değerleri hesaplayalım
        var totalUSD = response.Data
            .Where(m => m.CurrencyType == "USD")
            .Sum(m => m.TotalValue);

        var totalEUR = response.Data
            .Where(m => m.CurrencyType == "EUR")
            .Sum(m => m.TotalValue);

        var totalTRY = response.Data
            .Where(m => m.CurrencyType == "TRY")
            .Sum(m => m.TotalValue);

        // Bu değerleri geri dönecek DTO'ya yerleştiriyoruz
        var moneyTotals = new MoneyTotalsDto
        {
            TotalUSD = totalUSD,
            TotalEUR = totalEUR,
            TotalTRY = totalTRY
        };

        return new ServiceResponse<MoneyTotalsDto>
        {
            Success = true,
            Data = moneyTotals,
            Message = "Total values retrieved successfully."
        };
    }
}

}
