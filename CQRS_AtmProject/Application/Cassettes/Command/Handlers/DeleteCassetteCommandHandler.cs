using System.Threading;
using System.Threading.Tasks;
using MediatR;
using CQRS_AtmProject.Application.Dtos.Cassettes;
using CQRS_AtmProject.Domain.Models;
using CQRS_AtmProject.Infrastructure.Data.Repositories.Cassettes;

namespace CQRS_AtmProject.Application.Cassettes.Command.Handlers
{
    public class DeleteCassetteCommandHandler : IRequestHandler<DeleteCassetteCommand, ServiceResponse<bool>>
    {
        private readonly ICassetteRepository _cassetteRepository;

        public DeleteCassetteCommandHandler(ICassetteRepository cassetteRepository)
        {
            _cassetteRepository = cassetteRepository;
        }

        public async Task<ServiceResponse<bool>> Handle(DeleteCassetteCommand request, CancellationToken cancellationToken)
        {
            var cassette = await _cassetteRepository.GetCassetteByIdAsync(request.Id);
            if (cassette == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = $"Cassette with ID {request.Id} not found."
                };
            }

            await _cassetteRepository.DeleteCassetteAsync(cassette);
            await _cassetteRepository.SaveChangesAsync();

            return new ServiceResponse<bool>
            {
                Success = true,
                Data = true,
                Message = $"Cassette with ID {request.Id} has been deleted successfully."
            };
        }
    }
}
