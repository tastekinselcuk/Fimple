using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using UserProductManagementAPI.Application.Dtos.Atms;
using UserProductManagementAPI.Domain.Models;

namespace UserProductManagementAPI.Application.Atms.Commands
{
    public class CreateAtmCommand : IRequest<ServiceResponse<AtmDto>>
    {
        public int DepositOnlyCount { get; set; }
        public int ForeignCurrencyOnlyCount { get; set; }
        public int TotalCassette { get; set; }        
        
    }
}