using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using CQRS_AtmProject.Domain.Models;

namespace CQRS_AtmProject.Application.Atms.Commands
{
    public class DeleteAtmCommand : IRequest<ServiceResponse<bool>>
    {
        public int Id { get; set; }
        
        
    }
}