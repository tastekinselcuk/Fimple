using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using CQRS_AtmProject.Domain.Models;

namespace CQRS_AtmProject.Application.Cassettes.Command
{
    public class DeleteCassetteCommand : IRequest<ServiceResponse<bool>>
    {
        public int Id { get; set; }
        
    }
}