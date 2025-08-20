using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiblioUniversity.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class adfaf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reservations_BookId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_StudentId",
                table: "Reservations");

            migrationBuilder.AlterColumn<string>(
                name: "Id_Card",
                table: "Persons",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_BookId",
                table: "Reservations",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_StudentId",
                table: "Reservations",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reservations_BookId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_StudentId",
                table: "Reservations");

            migrationBuilder.AlterColumn<string>(
                name: "Id_Card",
                table: "Persons",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_BookId",
                table: "Reservations",
                column: "BookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_StudentId",
                table: "Reservations",
                column: "StudentId",
                unique: true);
        }
    }
}
