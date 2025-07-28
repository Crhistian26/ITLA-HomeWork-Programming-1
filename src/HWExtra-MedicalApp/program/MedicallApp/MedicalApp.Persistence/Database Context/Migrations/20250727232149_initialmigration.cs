using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rol",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Rols",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rols",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "Rol",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
