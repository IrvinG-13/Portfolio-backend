using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace irvinPortfolio.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_modeloUsuarios",
                table: "modeloUsuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_modeloProyectos",
                table: "modeloProyectos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_modeloMensajeContacto",
                table: "modeloMensajeContacto");

            migrationBuilder.RenameTable(
                name: "modeloUsuarios",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "modeloProyectos",
                newName: "Proyectos");

            migrationBuilder.RenameTable(
                name: "modeloMensajeContacto",
                newName: "MensajesContacto");

            migrationBuilder.AlterColumn<bool>(
                name: "Destacado",
                table: "Proyectos",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Leido",
                table: "MensajesContacto",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proyectos",
                table: "Proyectos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MensajesContacto",
                table: "MensajesContacto",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "FechaCreacion", "PasswordHash", "Rol", "Username" },
                values: new object[] { 1, new DateTime(2025, 12, 14, 15, 19, 29, 447, DateTimeKind.Local).AddTicks(3133), "Panama0513", "Admin", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proyectos",
                table: "Proyectos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MensajesContacto",
                table: "MensajesContacto");

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "modeloUsuarios");

            migrationBuilder.RenameTable(
                name: "Proyectos",
                newName: "modeloProyectos");

            migrationBuilder.RenameTable(
                name: "MensajesContacto",
                newName: "modeloMensajeContacto");

            migrationBuilder.AlterColumn<bool>(
                name: "Destacado",
                table: "modeloProyectos",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "Leido",
                table: "modeloMensajeContacto",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_modeloUsuarios",
                table: "modeloUsuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_modeloProyectos",
                table: "modeloProyectos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_modeloMensajeContacto",
                table: "modeloMensajeContacto",
                column: "Id");
        }
    }
}
