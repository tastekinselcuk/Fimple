using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using UserProductManagementAPI.Application.Dtos.CurrencyDenominations;
using UserProductManagementAPI.Domain.Enums;
using UserProductManagementAPI.Domain.Models;

namespace UserProductManagementAPI.Application.CurrencyDenominations.Command
{
    public class UpdateCurrencyDenominationCommand : IRequest<ServiceResponse<CurrencyDenominationDto>>
    {
    public int Id { get; set; }
    public CurrencyType CurrencyType { get; set; }
    public DenominationType DenominationType { get; set; }
    public int Quantity { get; set; }
    public int CassetteId { get; set; }      
    }
}