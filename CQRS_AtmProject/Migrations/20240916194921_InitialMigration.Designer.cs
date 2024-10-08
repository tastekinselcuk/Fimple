﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using CQRS_AtmProject.Data;

#nullable disable

namespace CQRS_AtmProject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240916194921_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CQRS_AtmProject.Domain.Models.Atm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepositOnlyCount")
                        .HasColumnType("int");

                    b.Property<int>("ForeignCurrencyOnlyCount")
                        .HasColumnType("int");

                    b.Property<int>("TotalCassette")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Atms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DepositOnlyCount = 1,
                            ForeignCurrencyOnlyCount = 2,
                            TotalCassette = 5
                        });
                });

            modelBuilder.Entity("CQRS_AtmProject.Domain.Models.Cassette", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AtmId")
                        .HasColumnType("int");

                    b.Property<int>("ExistQuantity")
                        .HasColumnType("int");

                    b.Property<bool>("IsDepositOnly")
                        .HasColumnType("bit");

                    b.Property<bool>("IsForeignCurrencyOnly")
                        .HasColumnType("bit");

                    b.Property<int>("QuantityCapacity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AtmId");

                    b.ToTable("Cassettes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AtmId = 1,
                            ExistQuantity = 0,
                            IsDepositOnly = true,
                            IsForeignCurrencyOnly = false,
                            QuantityCapacity = 100
                        },
                        new
                        {
                            Id = 2,
                            AtmId = 1,
                            ExistQuantity = 40,
                            IsDepositOnly = false,
                            IsForeignCurrencyOnly = true,
                            QuantityCapacity = 100
                        },
                        new
                        {
                            Id = 3,
                            AtmId = 1,
                            ExistQuantity = 40,
                            IsDepositOnly = false,
                            IsForeignCurrencyOnly = true,
                            QuantityCapacity = 100
                        },
                        new
                        {
                            Id = 4,
                            AtmId = 1,
                            ExistQuantity = 40,
                            IsDepositOnly = false,
                            IsForeignCurrencyOnly = false,
                            QuantityCapacity = 100
                        },
                        new
                        {
                            Id = 5,
                            AtmId = 1,
                            ExistQuantity = 40,
                            IsDepositOnly = false,
                            IsForeignCurrencyOnly = false,
                            QuantityCapacity = 100
                        });
                });

            modelBuilder.Entity("CQRS_AtmProject.Domain.Models.CurrencyDenomination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CassetteId")
                        .HasColumnType("int");

                    b.Property<int>("CurrencyType")
                        .HasColumnType("int");

                    b.Property<int>("DenominationType")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CassetteId");

                    b.ToTable("CurrencyDenominations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CassetteId = 1,
                            CurrencyType = 2,
                            DenominationType = 20,
                            Quantity = 0
                        },
                        new
                        {
                            Id = 2,
                            CassetteId = 1,
                            CurrencyType = 2,
                            DenominationType = 50,
                            Quantity = 0
                        },
                        new
                        {
                            Id = 3,
                            CassetteId = 1,
                            CurrencyType = 2,
                            DenominationType = 100,
                            Quantity = 0
                        },
                        new
                        {
                            Id = 4,
                            CassetteId = 1,
                            CurrencyType = 2,
                            DenominationType = 500,
                            Quantity = 0
                        },
                        new
                        {
                            Id = 5,
                            CassetteId = 1,
                            CurrencyType = 0,
                            DenominationType = 20,
                            Quantity = 0
                        },
                        new
                        {
                            Id = 6,
                            CassetteId = 1,
                            CurrencyType = 0,
                            DenominationType = 50,
                            Quantity = 0
                        },
                        new
                        {
                            Id = 7,
                            CassetteId = 1,
                            CurrencyType = 0,
                            DenominationType = 100,
                            Quantity = 0
                        },
                        new
                        {
                            Id = 8,
                            CassetteId = 1,
                            CurrencyType = 0,
                            DenominationType = 500,
                            Quantity = 0
                        },
                        new
                        {
                            Id = 9,
                            CassetteId = 1,
                            CurrencyType = 1,
                            DenominationType = 20,
                            Quantity = 0
                        },
                        new
                        {
                            Id = 10,
                            CassetteId = 1,
                            CurrencyType = 1,
                            DenominationType = 50,
                            Quantity = 0
                        },
                        new
                        {
                            Id = 11,
                            CassetteId = 1,
                            CurrencyType = 1,
                            DenominationType = 100,
                            Quantity = 0
                        },
                        new
                        {
                            Id = 12,
                            CassetteId = 1,
                            CurrencyType = 1,
                            DenominationType = 500,
                            Quantity = 0
                        },
                        new
                        {
                            Id = 13,
                            CassetteId = 2,
                            CurrencyType = 0,
                            DenominationType = 20,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 14,
                            CassetteId = 2,
                            CurrencyType = 0,
                            DenominationType = 50,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 15,
                            CassetteId = 2,
                            CurrencyType = 0,
                            DenominationType = 100,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 16,
                            CassetteId = 2,
                            CurrencyType = 0,
                            DenominationType = 500,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 17,
                            CassetteId = 3,
                            CurrencyType = 1,
                            DenominationType = 20,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 18,
                            CassetteId = 3,
                            CurrencyType = 1,
                            DenominationType = 50,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 19,
                            CassetteId = 3,
                            CurrencyType = 1,
                            DenominationType = 100,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 20,
                            CassetteId = 3,
                            CurrencyType = 1,
                            DenominationType = 500,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 21,
                            CassetteId = 4,
                            CurrencyType = 2,
                            DenominationType = 20,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 22,
                            CassetteId = 4,
                            CurrencyType = 2,
                            DenominationType = 50,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 23,
                            CassetteId = 4,
                            CurrencyType = 2,
                            DenominationType = 100,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 24,
                            CassetteId = 4,
                            CurrencyType = 2,
                            DenominationType = 500,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 25,
                            CassetteId = 5,
                            CurrencyType = 2,
                            DenominationType = 20,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 26,
                            CassetteId = 5,
                            CurrencyType = 2,
                            DenominationType = 50,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 27,
                            CassetteId = 5,
                            CurrencyType = 2,
                            DenominationType = 100,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 28,
                            CassetteId = 5,
                            CurrencyType = 2,
                            DenominationType = 500,
                            Quantity = 10
                        });
                });

            modelBuilder.Entity("CQRS_AtmProject.Domain.Models.Cassette", b =>
                {
                    b.HasOne("CQRS_AtmProject.Domain.Models.Atm", "Atm")
                        .WithMany("Cassettes")
                        .HasForeignKey("AtmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Atm");
                });

            modelBuilder.Entity("CQRS_AtmProject.Domain.Models.CurrencyDenomination", b =>
                {
                    b.HasOne("CQRS_AtmProject.Domain.Models.Cassette", "Cassette")
                        .WithMany("CurrencyDenominations")
                        .HasForeignKey("CassetteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cassette");
                });

            modelBuilder.Entity("CQRS_AtmProject.Domain.Models.Atm", b =>
                {
                    b.Navigation("Cassettes");
                });

            modelBuilder.Entity("CQRS_AtmProject.Domain.Models.Cassette", b =>
                {
                    b.Navigation("CurrencyDenominations");
                });
#pragma warning restore 612, 618
        }
    }
}
