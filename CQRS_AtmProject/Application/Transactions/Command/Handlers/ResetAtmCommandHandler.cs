using MediatR;
using CQRS_AtmProject.Data;
using CQRS_AtmProject.Domain.Models;
using System.Threading;
using System.Threading.Tasks;
using CQRS_AtmProject.Application.Transactions.Command;
using System.Linq;
using CQRS_AtmProject.Application.Dtos;

namespace CQRS_AtmProject.Application.Handlers
{
    public class ResetAtmCommandHandler : IRequestHandler<ResetAtmCommand, ServiceResponse<bool>>
    {
        private readonly AppDbContext _context;

        public ResetAtmCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<bool>> Handle(ResetAtmCommand request, CancellationToken cancellationToken)
        {
            var atm = await _context.Atms.FindAsync(request.AtmId);
            if (atm == null)
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Message = "ATM not found"
                };


            // ATM reset
            atm.DepositOnlyCount = 1;
            atm.ForeignCurrencyOnlyCount = 2;
            atm.TotalCassette = 5;

            // Cassettes reset
            var cassettes = _context.Cassettes.Where(c => c.AtmId == request.AtmId).ToList();
            foreach (var cassette in cassettes)
            {
                switch (cassette.Id)
                {
                    case 1:
                        cassette.QuantityCapacity = 100;
                        cassette.ExistQuantity = 0;
                        cassette.IsDepositOnly = true;
                        cassette.IsForeignCurrencyOnly = false;
                        break;

                    case 2:
                    case 3:
                        cassette.QuantityCapacity = 100;
                        cassette.ExistQuantity = 40;
                        cassette.IsDepositOnly = false;
                        cassette.IsForeignCurrencyOnly = true;
                        break;

                    default:
                        cassette.QuantityCapacity = 100;
                        cassette.ExistQuantity = 40;
                        cassette.IsDepositOnly = false;
                        cassette.IsForeignCurrencyOnly = false;
                        break;
                }
            }

            // CurrencyDenominations reset
            var currencyDenominations = _context.CurrencyDenominations.ToList();
            foreach (var denomination in currencyDenominations)
            {
                denomination.Quantity = denomination.CassetteId == 1 ? 0 : 10;
            }

            await _context.SaveChangesAsync(cancellationToken);

            return new ServiceResponse<bool>
            {
                Data = true,
                Success = true,
                Message = "The ATM was successfully reset."
            };
        }
    }
}
