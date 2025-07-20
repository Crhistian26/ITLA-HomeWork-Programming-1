using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CheckKeys2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Persons_PersonId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Persons_PersonId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_PersonId",
                table: "Doctors");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_PersonId",
                table: "Doctors",
                column: "PersonId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Persons_PersonId",
                table: "Doctors",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Persons_PersonId",
                table: "Patients",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Persons_PersonId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Persons_PersonId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_PersonId",
                table: "Doctors");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Doctors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_PersonId",
                table: "Doctors",
                column: "PersonId",
                unique: true,
                filter: "[PersonId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Persons_PersonId",
                table: "Doctors",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Persons_PersonId",
                table: "Patients",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
