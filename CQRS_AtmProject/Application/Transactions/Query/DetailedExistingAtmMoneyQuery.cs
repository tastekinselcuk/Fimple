using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS_AtmProject.Application.Dtos;
using CQRS_AtmProject.Application.Dtos.ExistingMoney;
using CQRS_AtmProject.Domain.Models;
using MediatR;

namespace CQRS_AtmProject.Application.Transactions.Query
{
    public class DetailedExistingAtmMoneyQuery : IRequest<ServiceResponse<List<ExistingMoneyDto>>>
    {
        public int AtmId { get; set; }
    }
}