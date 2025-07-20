using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FinaldeDomain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultation_Doctors_DoctorId",
                table: "Consultation");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultation_Patients_PatientId",
                table: "Consultation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Consultation",
                table: "Consultation");

            migrationBuilder.RenameTable(
                name: "Consultation",
                newName: "Consultations");

            migrationBuilder.RenameIndex(
                name: "IX_Consultation_PatientId",
                table: "Consultations",
                newName: "IX_Consultations_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Consultation_DoctorId",
                table: "Consultations",
                newName: "IX_Consultations_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Consultations",
                table: "Consultations",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rol = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Auditories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameTable = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTable = table.Column<int>(type: "int", nullable: false),
                    EntityState = table.Column<int>(type: "int", nullable: false),
                    OldDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auditories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auditories_UserId",
                table: "Auditories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DoctorId",
                table: "Users",
                column: "DoctorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_Doctors_DoctorId",
                table: "Consultations",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_Patients_PatientId",
                table: "Consultations",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultations_Doctors_DoctorId",
                table: "Consultations");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultations_Patients_PatientId",
                table: "Consultations");

            migrationBuilder.DropTable(
                name: "Auditories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Consultations",
                table: "Consultations");

            migrationBuilder.RenameTable(
                name: "Consultations",
                newName: "Consultation");

            migrationBuilder.RenameIndex(
                name: "IX_Consultations_PatientId",
                table: "Consultation",
                newName: "IX_Consultation_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Consultations_DoctorId",
                table: "Consultation",
                newName: "IX_Consultation_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Consultation",
                table: "Consultation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultation_Doctors_DoctorId",
                table: "Consultation",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultation_Patients_PatientId",
                table: "Consultation",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
