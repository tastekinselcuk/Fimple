using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UserProductManagementAPI.Domain.Models;
using UserProductManagementAPI.Infrastructure.Data.Repositories.Atms;

namespace UserProductManagementAPI.Application.Atms.Commands.Handlers
{
    public class DeleteAtmCommandHandler : IRequestHandler<DeleteAtmCommand, ServiceResponse<bool>>
    {
        private readonly IAtmRepository _atmRepository;

        public DeleteAtmCommandHandler(IAtmRepository atmRepository)
        {
            _atmRepository = atmRepository;
        }

        public async Task<ServiceResponse<bool>> Handle(DeleteAtmCommand request, CancellationToken cancellationToken)
        {
            var atm = await _atmRepository.GetAtmByIdAsync(request.Id);

            if (atm == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = $"ATM with ID {request.Id} not found."
                };
            }

            await _atmRepository.DeleteAtmAsync(atm);
            await _atmRepository.SaveChangesAsync();

            return new ServiceResponse<bool>
            {
                Success = true,
                Data = true,
                Message = $"ATM with ID {request.Id} has been deleted successfully."
            };
        }
    }
}
