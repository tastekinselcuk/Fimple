using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using UserProductManagementAPI.Domain.Models;

namespace UserProductManagementAPI.Application.CurrencyDenominations.Command
{
    public class DeleteCurrencyDenominationCommand : IRequest<ServiceResponse<bool>>
    {
        public int Id { get; set; }
        
        
    }
}