using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BiblioUniversity.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedforBookAuthorAndRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Books_BooksId",
                table: "AuthorBook");

            migrationBuilder.DropForeignKey(
                name: "FK_BookGenre_Books_BooksId",
                table: "BookGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_BookLanguage_Books_BooksId",
                table: "BookLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_Fines_Reservations_ReservationId",
                table: "Fines");

            migrationBuilder.DropForeignKey(
                name: "FK_Librarianes_Persons_PersonId",
                table: "Librarianes");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Books_BookId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Students_StudentId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Books_BookId",
                table: "Stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Enrollment_EnrollmentId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Persons_PersonId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Persons_PersonId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_BookId",
                table: "Stocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Librarianes",
                table: "Librarianes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fines",
                table: "Fines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Estudiantes");

            migrationBuilder.RenameTable(
                name: "Stocks",
                newName: "StockDeLibros");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "Reservaciones");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "Personas");

            migrationBuilder.RenameTable(
                name: "Librarianes",
                newName: "Bibliotecarios");

            migrationBuilder.RenameTable(
                name: "Fines",
                newName: "Multas");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "Libros");

            migrationBuilder.RenameIndex(
                name: "IX_Users_PersonId",
                table: "Usuarios",
                newName: "IX_Usuarios_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_PersonId",
                table: "Estudiantes",
                newName: "IX_Estudiantes_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_EnrollmentId",
                table: "Estudiantes",
                newName: "IX_Estudiantes_EnrollmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_StudentId",
                table: "Reservaciones",
                newName: "IX_Reservaciones_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_BookId",
                table: "Reservaciones",
                newName: "IX_Reservaciones_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Librarianes_PersonId",
                table: "Bibliotecarios",
                newName: "IX_Bibliotecarios_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Fines_ReservationId",
                table: "Multas",
                newName: "IX_Multas_ReservationId");

            migrationBuilder.AlterColumn<string>(
                name: "License",
                table: "Bibliotecarios",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estudiantes",
                table: "Estudiantes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockDeLibros",
                table: "StockDeLibros",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservaciones",
                table: "Reservaciones",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personas",
                table: "Personas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bibliotecarios",
                table: "Bibliotecarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Multas",
                table: "Multas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Libros",
                table: "Libros",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Shakespeare" });

            migrationBuilder.InsertData(
                table: "Libros",
                columns: new[] { "Id", "Edition", "Pages", "Title", "Url_digital", "Url_image" },
                values: new object[] { 1, "1ra", 256, "Hamlet", "", "" });

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "Id", "Address", "Id_Card", "Lastname", "Name", "Telephone" },
                values: new object[,]
                {
                    { 2, "Los Mina", "40234544556", "Ramirez Carrasco", "Pedro Alvarez", "8295678976" },
                    { 3, "Santo Domingo Este", "40298765432", "Gomez Castillo", "Laura Martinez", "8092345678" },
                    { 4, "Villa Mella", "40287654321", "Torres Mejia", "Jose Ramirez", "8293456789" },
                    { 5, "San Cristobal", "40276543210", "Lopez Santana", "Carla Fernandez", "8494567890" },
                    { 6, "Boca Chica", "40265432109", "Morales Diaz", "Luis Castillo", "8095678901" },
                    { 7, "La Capital", "43123435654", "Benedict Torvalds", "Linus", "8297768909" }
                });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorsId", "BooksId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_StockDeLibros_BookId",
                table: "StockDeLibros",
                column: "BookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Id_Card",
                table: "Personas",
                column: "Id_Card",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bibliotecarios_License",
                table: "Bibliotecarios",
                column: "License",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Libros_BooksId",
                table: "AuthorBook",
                column: "BooksId",
                principalTable: "Libros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bibliotecarios_Personas_PersonId",
                table: "Bibliotecarios",
                column: "PersonId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookGenre_Libros_BooksId",
                table: "BookGenre",
                column: "BooksId",
                principalTable: "Libros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookLanguage_Libros_BooksId",
                table: "BookLanguage",
                column: "BooksId",
                principalTable: "Libros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiantes_Enrollment_EnrollmentId",
                table: "Estudiantes",
                column: "EnrollmentId",
                principalTable: "Enrollment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiantes_Personas_PersonId",
                table: "Estudiantes",
                column: "PersonId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Multas_Reservaciones_ReservationId",
                table: "Multas",
                column: "ReservationId",
                principalTable: "Reservaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservaciones_Estudiantes_StudentId",
                table: "Reservaciones",
                column: "StudentId",
                principalTable: "Estudiantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservaciones_Libros_BookId",
                table: "Reservaciones",
                column: "BookId",
                principalTable: "Libros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockDeLibros_Libros_BookId",
                table: "StockDeLibros",
                column: "BookId",
                principalTable: "Libros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Personas_PersonId",
                table: "Usuarios",
                column: "PersonId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Libros_BooksId",
                table: "AuthorBook");

            migrationBuilder.DropForeignKey(
                name: "FK_Bibliotecarios_Personas_PersonId",
                table: "Bibliotecarios");

            migrationBuilder.DropForeignKey(
                name: "FK_BookGenre_Libros_BooksId",
                table: "BookGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_BookLanguage_Libros_BooksId",
                table: "BookLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_Estudiantes_Enrollment_EnrollmentId",
                table: "Estudiantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Estudiantes_Personas_PersonId",
                table: "Estudiantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Multas_Reservaciones_ReservationId",
                table: "Multas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservaciones_Estudiantes_StudentId",
                table: "Reservaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservaciones_Libros_BookId",
                table: "Reservaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_StockDeLibros_Libros_BookId",
                table: "StockDeLibros");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Personas_PersonId",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockDeLibros",
                table: "StockDeLibros");

            migrationBuilder.DropIndex(
                name: "IX_StockDeLibros_BookId",
                table: "StockDeLibros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservaciones",
                table: "Reservaciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personas",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_Id_Card",
                table: "Personas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Multas",
                table: "Multas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Libros",
                table: "Libros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estudiantes",
                table: "Estudiantes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bibliotecarios",
                table: "Bibliotecarios");

            migrationBuilder.DropIndex(
                name: "IX_Bibliotecarios_License",
                table: "Bibliotecarios");

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "StockDeLibros",
                newName: "Stocks");

            migrationBuilder.RenameTable(
                name: "Reservaciones",
                newName: "Reservations");

            migrationBuilder.RenameTable(
                name: "Personas",
                newName: "Persons");

            migrationBuilder.RenameTable(
                name: "Multas",
                newName: "Fines");

            migrationBuilder.RenameTable(
                name: "Libros",
                newName: "Books");

            migrationBuilder.RenameTable(
                name: "Estudiantes",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "Bibliotecarios",
                newName: "Librarianes");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_PersonId",
                table: "Users",
                newName: "IX_Users_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservaciones_StudentId",
                table: "Reservations",
                newName: "IX_Reservations_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservaciones_BookId",
                table: "Reservations",
                newName: "IX_Reservations_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Multas_ReservationId",
                table: "Fines",
                newName: "IX_Fines_ReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_Estudiantes_PersonId",
                table: "Students",
                newName: "IX_Students_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Estudiantes_EnrollmentId",
                table: "Students",
                newName: "IX_Students_EnrollmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Bibliotecarios_PersonId",
                table: "Librarianes",
                newName: "IX_Librarianes_PersonId");

            migrationBuilder.AlterColumn<string>(
                name: "License",
                table: "Librarianes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fines",
                table: "Fines",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Librarianes",
                table: "Librarianes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_BookId",
                table: "Stocks",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Books_BooksId",
                table: "AuthorBook",
                column: "BooksId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookGenre_Books_BooksId",
                table: "BookGenre",
                column: "BooksId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookLanguage_Books_BooksId",
                table: "BookLanguage",
                column: "BooksId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fines_Reservations_ReservationId",
                table: "Fines",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Librarianes_Persons_PersonId",
                table: "Librarianes",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Books_BookId",
                table: "Reservations",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Students_StudentId",
                table: "Reservations",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Books_BookId",
                table: "Stocks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Enrollment_EnrollmentId",
                table: "Students",
                column: "EnrollmentId",
                principalTable: "Enrollment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Persons_PersonId",
                table: "Students",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Persons_PersonId",
                table: "Users",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
