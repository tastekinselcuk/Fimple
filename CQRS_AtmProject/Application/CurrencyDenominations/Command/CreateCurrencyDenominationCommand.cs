using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using CQRS_AtmProject.Application.Dtos.CurrencyDenominations;
using CQRS_AtmProject.Domain.Enums;
using CQRS_AtmProject.Domain.Models;

namespace CQRS_AtmProject.Application.CurrencyDenominations.Command
{
    public class CreateCurrencyDenominationCommand : IRequest<ServiceResponse<CurrencyDenominationDto>>
    {
    public CurrencyType CurrencyType { get; set; }
    public DenominationType DenominationType { get; set; }
    public int Quantity { get; set; }
    public int CassetteId { get; set; }        
        
    }
}