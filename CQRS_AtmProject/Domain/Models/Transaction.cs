// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using CQRS_AtmProject.Domain.Enums;

// namespace CQRS_AtmProject.Domain.Models
// {
//     public class Transaction
//     {
//         public int Id { get; set; }
//         public DateTime TransactionDate { get; set; }
//         public TransactionType TransactionType { get; set; }
//         public decimal Amount { get; set; }
//         public int AtmId { get; set; }
//         public Atm Atm { get; set; }
//         public int CassetteId { get; set; }
//         public Cassette Cassette { get; set; }
//         public string Description { get; set; }
//     }
// }