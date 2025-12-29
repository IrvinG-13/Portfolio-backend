using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace irvinPortfolio.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarSeedAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "PasswordHash" },
                values: new object[] { new DateTime(2025, 12, 14, 16, 53, 19, 90, DateTimeKind.Local).AddTicks(6555), "Panama0513SuperSeguro!" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "PasswordHash" },
                values: new object[] { new DateTime(2025, 12, 14, 15, 19, 29, 447, DateTimeKind.Local).AddTicks(3133), "Panama0513" });
        }
    }
}
