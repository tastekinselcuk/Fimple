using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using UserProductManagementAPI.Application.Dtos.Cassettes;
using UserProductManagementAPI.Domain.Models;

namespace UserProductManagementAPI.Application.Cassettes.Query
{
    public class GetAllCassetteQuery : IRequest<ServiceResponse<List<CassetteDto>>>
    {
        
    }
}