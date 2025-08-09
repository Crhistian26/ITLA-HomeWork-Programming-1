using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiblioUniversity.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enrollment",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "EnrollmentId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_EnrollmentId",
                table: "Students",
                column: "EnrollmentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Enrollment_EnrollmentId",
                table: "Students",
                column: "EnrollmentId",
                principalTable: "Enrollment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Enrollment_EnrollmentId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropIndex(
                name: "IX_Students_EnrollmentId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "EnrollmentId",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "Enrollment",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
