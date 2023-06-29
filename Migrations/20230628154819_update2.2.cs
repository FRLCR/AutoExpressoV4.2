using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AEFINAL.Migrations
{
    /// <inheritdoc />
    public partial class update22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "nombrecompleto",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nombrecompleto",
                table: "Clientes");
        }
    }
}
