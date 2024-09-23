using System;
using System.Collections.Generic;
using MediatR;
using CQRS_AtmProject.Application.Dtos.Atms;
using CQRS_AtmProject.Domain.Models;
using CQRS_AtmProject.Application.Dtos.ExistingMoney;

namespace CQRS_AtmProject.Application.Atms.Queries
{
    public class ExistingMoneyQuery : IRequest<ServiceResponse<MoneyTotalsDto>>
    {
        public int AtmId { get; set; }
    }
}
