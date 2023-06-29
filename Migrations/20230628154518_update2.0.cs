using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AEFINAL.Migrations
{
    /// <inheritdoc />
    public partial class update20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    documento = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    correoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.documento);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    precio = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    matricula = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    clientedocumento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.matricula);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Clientes_clientedocumento",
                        column: x => x.clientedocumento,
                        principalTable: "Clientes",
                        principalColumn: "documento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registros",
                columns: table => new
                {
                    nroOrden = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vehiculomatricula = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    servicioid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registros", x => x.nroOrden);
                    table.ForeignKey(
                        name: "FK_Registros_Servicios_servicioid",
                        column: x => x.servicioid,
                        principalTable: "Servicios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registros_Vehiculos_vehiculomatricula",
                        column: x => x.vehiculomatricula,
                        principalTable: "Vehiculos",
                        principalColumn: "matricula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registros_servicioid",
                table: "Registros",
                column: "servicioid");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_vehiculomatricula",
                table: "Registros",
                column: "vehiculomatricula");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_clientedocumento",
                table: "Vehiculos",
                column: "clientedocumento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registros");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
