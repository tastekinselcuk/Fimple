using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS_AtmProject.Domain.Models;
using MediatR;

namespace CQRS_AtmProject.Application.Transactions.Command
{
    public class ResetAtmCommand : IRequest<ServiceResponse<bool>>
    {
        public int AtmId { get; set; }
    }
}