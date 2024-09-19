using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using CQRS_AtmProject.Application.Dtos.Atms;
using CQRS_AtmProject.Domain.Models;

namespace CQRS_AtmProject.Application.Atms.Queries
{
    public class GetAtmByIdQuery : IRequest<ServiceResponse<AtmDto>>
    {
        public int Id { get; set; }
    }
}