using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using CQRS_AtmProject.Application.Dtos.Atms;
using CQRS_AtmProject.Domain.Models;

namespace CQRS_AtmProject.Application.Atms.Commands
{
    public class CreateAtmCommand : IRequest<ServiceResponse<AtmDto>>
    {
        public int DepositOnlyCount { get; set; }
        public int ForeignCurrencyOnlyCount { get; set; }
        public int TotalCassette { get; set; }        
        
    }
}