using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CQRS_AtmProject.Domain.Enums;
using CQRS_AtmProject.Domain.Models;

namespace CQRS_AtmProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }
        public DbSet<Atm> Atms {get; set;}
        public DbSet<Cassette> Cassettes {get; set;}
        public DbSet<CurrencyDenomination> CurrencyDenominations {get; set;}
        // public DbSet<Transaction> Transactions {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Atm>()
                .HasMany(a => a.Cassettes)
                .WithOne(c => c.Atm)
                .HasForeignKey(c => c.AtmId);

            modelBuilder.Entity<Cassette>()
                .HasMany(c => c.CurrencyDenominations)
                .WithOne(d => d.Cassette)
                .HasForeignKey(d => d.CassetteId);

            // Seed data for Atm, Cassettes, and CurrencyDenomination
            modelBuilder.Entity<Atm>().HasData(new Atm
            {
                Id = 1,
                DepositOnlyCount = 1,
                ForeignCurrencyOnlyCount = 2,
                TotalCassette = 5
            });

            // Seeding 5 Cassettes
            modelBuilder.Entity<Cassette>().HasData(
                // Cassette 1: Deposit only, handles TRY
                new Cassette
                {
                    Id = 1,
                    QuantityCapacity = 100,
                    ExistQuantity = 0,
                    IsDepositOnly = true,
                    IsForeignCurrencyOnly = false,
                    AtmId = 1
                },
                // Cassette 2: Handles USD only
                new Cassette
                {
                    Id = 2,
                    QuantityCapacity = 100,
                    ExistQuantity = 40,
                    IsDepositOnly = false,
                    IsForeignCurrencyOnly = true,
                    AtmId = 1
                },
                // Cassette 3: Handles EUR only
                new Cassette
                {
                    Id = 3,
                    QuantityCapacity = 100,
                    ExistQuantity = 40,
                    IsDepositOnly = false,
                    IsForeignCurrencyOnly = true,
                    AtmId = 1
                },
                // Cassette 4: Handles TRY
                new Cassette
                {
                    Id = 4,
                    QuantityCapacity = 100,
                    ExistQuantity = 40,
                    IsDepositOnly = false,
                    IsForeignCurrencyOnly = false,
                    AtmId = 1
                },
                // Cassette 5: Handles TRY
                new Cassette
                {
                    Id = 5,
                    QuantityCapacity = 100,
                    ExistQuantity = 40,
                    IsDepositOnly = false,
                    IsForeignCurrencyOnly = false,
                    AtmId = 1
                }
            );

            // Seed CurrencyDenominations
            modelBuilder.Entity<CurrencyDenomination>().HasData(
                // Cassette 1 - DepositOnly (accepts all currencies: TRY, USD, EUR)
                new CurrencyDenomination { Id = 1, CassetteId = 1, DenominationType = DenominationType.Twenty, CurrencyType = CurrencyType.TRY, Quantity = 0 },
                new CurrencyDenomination { Id = 2, CassetteId = 1, DenominationType = DenominationType.Fifty, CurrencyType = CurrencyType.TRY, Quantity = 0 },
                new CurrencyDenomination { Id = 3, CassetteId = 1, DenominationType = DenominationType.OneHundred, CurrencyType = CurrencyType.TRY, Quantity = 0 },
                new CurrencyDenomination { Id = 4, CassetteId = 1, DenominationType = DenominationType.FiveHundred, CurrencyType = CurrencyType.TRY, Quantity = 0 },

                new CurrencyDenomination { Id = 5, CassetteId = 1, DenominationType = DenominationType.Twenty, CurrencyType = CurrencyType.USD, Quantity = 0 },
                new CurrencyDenomination { Id = 6, CassetteId = 1, DenominationType = DenominationType.Fifty, CurrencyType = CurrencyType.USD, Quantity = 0 },
                new CurrencyDenomination { Id = 7, CassetteId = 1, DenominationType = DenominationType.OneHundred, CurrencyType = CurrencyType.USD, Quantity = 0 },
                new CurrencyDenomination { Id = 8, CassetteId = 1, DenominationType = DenominationType.FiveHundred, CurrencyType = CurrencyType.USD, Quantity = 0 },

                new CurrencyDenomination { Id = 9, CassetteId = 1, DenominationType = DenominationType.Twenty, CurrencyType = CurrencyType.EUR, Quantity = 0 },
                new CurrencyDenomination { Id = 10, CassetteId = 1, DenominationType = DenominationType.Fifty, CurrencyType = CurrencyType.EUR, Quantity = 0 },
                new CurrencyDenomination { Id = 11, CassetteId = 1, DenominationType = DenominationType.OneHundred, CurrencyType = CurrencyType.EUR, Quantity = 0 },
                new CurrencyDenomination { Id = 12, CassetteId = 1, DenominationType = DenominationType.FiveHundred, CurrencyType = CurrencyType.EUR, Quantity = 0 },

                // Cassette 2: USD denominations
                new CurrencyDenomination { Id = 13, CassetteId = 2, DenominationType = DenominationType.Twenty, CurrencyType = CurrencyType.USD, Quantity = 10 },
                new CurrencyDenomination { Id = 14, CassetteId = 2, DenominationType = DenominationType.Fifty, CurrencyType = CurrencyType.USD, Quantity = 10 },
                new CurrencyDenomination { Id = 15, CassetteId = 2, DenominationType = DenominationType.OneHundred, CurrencyType = CurrencyType.USD, Quantity = 10 },
                new CurrencyDenomination { Id = 16, CassetteId = 2, DenominationType = DenominationType.FiveHundred, CurrencyType = CurrencyType.USD, Quantity = 10 },

                // Cassette 3: EUR denominations
                new CurrencyDenomination { Id = 17, CassetteId = 3, DenominationType = DenominationType.Twenty, CurrencyType = CurrencyType.EUR, Quantity = 10 },
                new CurrencyDenomination { Id = 18, CassetteId = 3, DenominationType = DenominationType.Fifty, CurrencyType = CurrencyType.EUR, Quantity = 10 },
                new CurrencyDenomination { Id = 19, CassetteId = 3, DenominationType = DenominationType.OneHundred, CurrencyType = CurrencyType.EUR, Quantity = 10 },
                new CurrencyDenomination { Id = 20, CassetteId = 3, DenominationType = DenominationType.FiveHundred, CurrencyType = CurrencyType.EUR, Quantity = 10 },

                // Cassette 4: TRY denominations
                new CurrencyDenomination { Id = 21, CassetteId = 4, DenominationType = DenominationType.Twenty, CurrencyType = CurrencyType.TRY, Quantity = 10 },
                new CurrencyDenomination { Id = 22, CassetteId = 4, DenominationType = DenominationType.Fifty, CurrencyType = CurrencyType.TRY, Quantity = 10 },
                new CurrencyDenomination { Id = 23, CassetteId = 4, DenominationType = DenominationType.OneHundred, CurrencyType = CurrencyType.TRY, Quantity = 10 },
                new CurrencyDenomination { Id = 24, CassetteId = 4, DenominationType = DenominationType.FiveHundred, CurrencyType = CurrencyType.TRY, Quantity = 10 },

                // Cassette 5: TRY denominations
                new CurrencyDenomination { Id = 25, CassetteId = 5, DenominationType = DenominationType.Twenty, CurrencyType = CurrencyType.TRY, Quantity = 10 },
                new CurrencyDenomination { Id = 26, CassetteId = 5, DenominationType = DenominationType.Fifty, CurrencyType = CurrencyType.TRY, Quantity = 10 },
                new CurrencyDenomination { Id = 27, CassetteId = 5, DenominationType = DenominationType.OneHundred, CurrencyType = CurrencyType.TRY, Quantity = 10 },
                new CurrencyDenomination { Id = 28, CassetteId = 5, DenominationType = DenominationType.FiveHundred, CurrencyType = CurrencyType.TRY, Quantity = 10 }
            );
            base.OnModelCreating(modelBuilder);
        }

    }
}