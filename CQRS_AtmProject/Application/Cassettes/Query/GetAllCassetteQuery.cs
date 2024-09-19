using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using CQRS_AtmProject.Application.Dtos.Cassettes;
using CQRS_AtmProject.Domain.Models;

namespace CQRS_AtmProject.Application.Cassettes.Query
{
    public class GetAllCassetteQuery : IRequest<ServiceResponse<List<CassetteDto>>>
    {
        
    }
}