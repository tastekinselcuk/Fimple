// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using AutoMapper;
// using CQRS_AtmProject.Application.Dtos;
// using CQRS_AtmProject.Domain.Models;
// using CQRS_AtmProject.Infrastructure.Data.Repositories.Atms;
// using CQRS_AtmProject.Infrastructure.Services;
// using MediatR;

// namespace CQRS_AtmProject.Application.Transactions.Query.Handlers
// {
// public class ExistingCassetteMoneyQueryHandler : IRequestHandler<ExistingCassetteMoneyQuery, ServiceResponse<List<ExistingMoneyDto>>>
// {
//     private readonly IAtmRepository _atmRepository;
//     private readonly IMapper _mapper;

//     public ExistingCassetteMoneyQueryHandler(IAtmRepository atmRepository, IMapper mapper)
//     {
//         _atmRepository = atmRepository;
//         _mapper = mapper;
//     }

//     public async Task<ServiceResponse<List<ExistingMoneyDto>>> Handle(ExistingCassetteMoneyQuery request, CancellationToken cancellationToken)
//     {
//         var atm = await _atmRepository.GetAtmByIdAsync(request.AtmId);
//         if (atm == null)
//         {
//             return new ServiceResponse<List<ExistingMoneyDto>>
//             {
//                 Success = false,
//                 Data = null,
//                 Message = $"ATM with ID {request.AtmId} not found."
//             };
//         }

//         // Belirtilen kaseti bulma
//         var cassette = atm.Cassettes.FirstOrDefault(c => c.Id == request.CassetteId);
//         if (cassette == null)
//         {
//             return new ServiceResponse<List<ExistingMoneyDto>>
//             {
//                 Success = false,
//                 Data = null,
//                 Message = $"Cassette with ID {request.CassetteId} not found."
//             };
//         }

//         // Sadece 4 farklı para birimi ve miktarını döndürme
//         var currencyDenominations = cassette.CurrencyDenominations
//             .Where(cd => cd.Quantity > 0)
//             .GroupBy(cd => new { cd.DenominationType, cd.CurrencyType })
//             .Select(g => new ExistingMoneyDto
//             {
//                 DenominationType = g.Key.DenominationType.ToString(),
//                 CurrencyType = g.Key.CurrencyType.ToString(),
//                 Quantity = g.Sum(cd => cd.Quantity),
//                 TotalValue = g.Sum(cd => cd.Quantity) * GetDenominationValue(g.Key.DenominationType.ToString(), g.Key.CurrencyType.ToString())
//             })
//             .Take(4) // Sadece 4 eleman al
//             .ToList();

//         return new ServiceResponse<List<ExistingMoneyDto>>
//         {
//             Success = true,
//             Data = currencyDenominations,
//             Message = "Currency denominations retrieved successfully."
//         };
//     }

//     private decimal GetDenominationValue(string denominationType, string currencyType)
//     {
//         return denominationType switch
//         {
//             "Twenty" => currencyType switch
//             {
//                 "USD" => 20,
//                 "EUR" => 20,
//                 "TRY" => 20,
//                 _ => 0
//             },
//             "Fifty" => currencyType switch
//             {
//                 "USD" => 50,
//                 "EUR" => 50,
//                 "TRY" => 50,
//                 _ => 0
//             },
//             "OneHundred" => currencyType switch
//             {
//                 "USD" => 100,
//                 "EUR" => 100,
//                 "TRY" => 100,
//                 _ => 0
//             },
//             "FiveHundred" => currencyType switch
//             {
//                 "USD" => 500,
//                 "EUR" => 500,
//                 "TRY" => 500,
//                 _ => 0
//             },
//             _ => 0
//         };
//     }
// }

// }