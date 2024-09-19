using System.Threading;
using System.Threading.Tasks;
using MediatR;
using CQRS_AtmProject.Domain.Models;
using CQRS_AtmProject.Infrastructure.Data.Repositories.CurrencyDenominations;

namespace CQRS_AtmProject.Application.CurrencyDenominations.Command.Handlers
{
    public class DeleteCurrencyDenominationCommandHandler : IRequestHandler<DeleteCurrencyDenominationCommand, ServiceResponse<bool>>
    {
        private readonly ICurrencyDenominationRepository _repository;

        public DeleteCurrencyDenominationCommandHandler(ICurrencyDenominationRepository repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResponse<bool>> Handle(DeleteCurrencyDenominationCommand request, CancellationToken cancellationToken)
        {
            var currencyDenomination = await _repository.GetCurrencyDenominationByIdAsync(request.Id);
            if (currencyDenomination == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = $"Currency Denomination with ID {request.Id} not found."
                };
            }

            await _repository.DeleteCurrencyDenominationAsync(currencyDenomination);
            await _repository.SaveChangesAsync();

            return new ServiceResponse<bool>
            {
                Success = true,
                Data = true,
                Message = $"Currency Denomination with ID {request.Id} has been deleted successfully."
            };
        }
    }
}
