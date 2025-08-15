using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiblioUniversity.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedForPerson1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Address", "Id_Card", "Lastname", "Name", "Telephone" },
                values: new object[] { 1, "Los Alcarrizos", "40214335478", "Perez Mendosa", "Fernando Garcia", "8097896786" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
