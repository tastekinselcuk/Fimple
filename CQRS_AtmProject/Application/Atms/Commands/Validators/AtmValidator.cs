// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using FluentValidation;
// using CQRS_AtmProject.Domain.Models;

// namespace CQRS_AtmProject.Application.Atms.Commands.Validators
// {
//     public class AtmValidator : AbstractValidator<Atm>
//     {
//     public AtmValidator()
//     {
//         RuleFor(atm => atm.TotalCassette)
//             .LessThanOrEqualTo(5)
//             .WithMessage("Total cassette count must be 5 or less.");

//         RuleFor(atm => atm.DepositOnlyCount)
//             .InclusiveBetween(1, 2)
//             .WithMessage("Deposit only count must be between 1 and 2.");

//         RuleFor(atm => atm.Cassettes.Count)
//             .Equal(atm => atm.TotalCassette)
//             .WithMessage("The number of cassettes must be equal to the total cassette count.");
//     }
//     }
// }