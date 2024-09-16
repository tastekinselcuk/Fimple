using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using UserProductManagementAPI.Application.Dtos.CurrencyDenominations;
using UserProductManagementAPI.Domain.Models;

namespace UserProductManagementAPI.Application.CurrencyDenominations.Query
{
    public class GetCurrencyDenominationByIdQuery : IRequest<ServiceResponse<CurrencyDenominationDto>>
    {
        public int Id { get; set; }
    }
}