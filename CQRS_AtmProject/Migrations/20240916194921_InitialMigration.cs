using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CQRS_AtmProject.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepositOnlyCount = table.Column<int>(type: "int", nullable: false),
                    ForeignCurrencyOnlyCount = table.Column<int>(type: "int", nullable: false),
                    TotalCassette = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cassettes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuantityCapacity = table.Column<int>(type: "int", nullable: false),
                    ExistQuantity = table.Column<int>(type: "int", nullable: false),
                    IsDepositOnly = table.Column<bool>(type: "bit", nullable: false),
                    IsForeignCurrencyOnly = table.Column<bool>(type: "bit", nullable: false),
                    AtmId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cassettes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cassettes_Atms_AtmId",
                        column: x => x.AtmId,
                        principalTable: "Atms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyDenominations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenominationType = table.Column<int>(type: "int", nullable: false),
                    CurrencyType = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CassetteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyDenominations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrencyDenominations_Cassettes_CassetteId",
                        column: x => x.CassetteId,
                        principalTable: "Cassettes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Atms",
                columns: new[] { "Id", "DepositOnlyCount", "ForeignCurrencyOnlyCount", "TotalCassette" },
                values: new object[] { 1, 1, 2, 5 });

            migrationBuilder.InsertData(
                table: "Cassettes",
                columns: new[] { "Id", "AtmId", "ExistQuantity", "IsDepositOnly", "IsForeignCurrencyOnly", "QuantityCapacity" },
                values: new object[,]
                {
                    { 1, 1, 0, true, false, 100 },
                    { 2, 1, 40, false, true, 100 },
                    { 3, 1, 40, false, true, 100 },
                    { 4, 1, 40, false, false, 100 },
                    { 5, 1, 40, false, false, 100 }
                });

            migrationBuilder.InsertData(
                table: "CurrencyDenominations",
                columns: new[] { "Id", "CassetteId", "CurrencyType", "DenominationType", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 2, 20, 0 },
                    { 2, 1, 2, 50, 0 },
                    { 3, 1, 2, 100, 0 },
                    { 4, 1, 2, 500, 0 },
                    { 5, 1, 0, 20, 0 },
                    { 6, 1, 0, 50, 0 },
                    { 7, 1, 0, 100, 0 },
                    { 8, 1, 0, 500, 0 },
                    { 9, 1, 1, 20, 0 },
                    { 10, 1, 1, 50, 0 },
                    { 11, 1, 1, 100, 0 },
                    { 12, 1, 1, 500, 0 },
                    { 13, 2, 0, 20, 10 },
                    { 14, 2, 0, 50, 10 },
                    { 15, 2, 0, 100, 10 },
                    { 16, 2, 0, 500, 10 },
                    { 17, 3, 1, 20, 10 },
                    { 18, 3, 1, 50, 10 },
                    { 19, 3, 1, 100, 10 },
                    { 20, 3, 1, 500, 10 },
                    { 21, 4, 2, 20, 10 },
                    { 22, 4, 2, 50, 10 },
                    { 23, 4, 2, 100, 10 },
                    { 24, 4, 2, 500, 10 },
                    { 25, 5, 2, 20, 10 },
                    { 26, 5, 2, 50, 10 },
                    { 27, 5, 2, 100, 10 },
                    { 28, 5, 2, 500, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cassettes_AtmId",
                table: "Cassettes",
                column: "AtmId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyDenominations_CassetteId",
                table: "CurrencyDenominations",
                column: "CassetteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrencyDenominations");

            migrationBuilder.DropTable(
                name: "Cassettes");

            migrationBuilder.DropTable(
                name: "Atms");
        }
    }
}
