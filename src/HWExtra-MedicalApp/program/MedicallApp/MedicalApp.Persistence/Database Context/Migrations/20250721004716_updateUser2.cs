using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateUser2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Consultations_ConsultationId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ConsultationId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ConsultationId",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConsultationId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ConsultationId",
                table: "Users",
                column: "ConsultationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Consultations_ConsultationId",
                table: "Users",
                column: "ConsultationId",
                principalTable: "Consultations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
