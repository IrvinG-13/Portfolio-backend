using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace irvinPortfolio.Migrations
{
    /// <inheritdoc />
    public partial class RemoveFechaEnvioContacto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaEnvio",
                table: "MensajesContacto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaEnvio",
                table: "MensajesContacto",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");
        }
    }
}
