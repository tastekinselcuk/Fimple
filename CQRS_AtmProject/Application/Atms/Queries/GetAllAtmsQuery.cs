using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using UserProductManagementAPI.Application.Dtos.Atms;
using UserProductManagementAPI.Domain.Models;

namespace UserProductManagementAPI.Application.Atms.Queries
{
    public class GetAllAtmsQuery : IRequest<ServiceResponse<List<AtmDto>>>
    {
    }
}