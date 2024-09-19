using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using CQRS_AtmProject.Application.Dtos.CurrencyDenominations;
using CQRS_AtmProject.Domain.Models;

namespace CQRS_AtmProject.Application.CurrencyDenominations.Query
{
    public class GetCurrencyDenominationByIdQuery : IRequest<ServiceResponse<CurrencyDenominationDto>>
    {
        public int Id { get; set; }
    }
}