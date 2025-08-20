using BiblioUniversity.Application.DTOs.CreateDTOs;
using BiblioUniversity.Application.DTOs.EntitiesDTOs;
using BiblioUniversity.Application.Interfaces;
using BiblioUniversity.Application.Services;
using BiblioUniversity.Domain.Entities.DataOnly;
using BiblioUniversity.Domain.Enum;
using BiblioUniversity.Domain.Interfaces.Repositories;
using BiblioUniversity.Infraestructure.BaseDatosContext;
using BiblioUniversity.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BiblioUniversity.Consola
{
    internal static class Program
    {
        private static BiblioContext context = new BiblioContext(new DbContextOptionsBuilder<BiblioContext>().Options);
        private static UsersRepository usersRepository = new UsersRepository(context);
        private static StudentsRepository studentsRepository = new StudentsRepository(context);
        private static LibrariansRepository librariansRepository = new LibrariansRepository(context);
        private static ReservationRepository reservationsRepository = new ReservationRepository(context);
        private static FinesRepository finesRepository = new FinesRepository(context);
        private static BooksRepositoy booksRepository = new BooksRepositoy(context);
        private static PersonsRepository personsRepository = new PersonsRepository(context);
        private static StockBooksRepository stockBooksRepository = new StockBooksRepository(context);
        private static IUserService _userService = new UserService(usersRepository);
        private static IStudentService _studentService = new StudentService(studentsRepository);
        private static ILibrarianService _librarianService = new LibrarianService(librariansRepository);
        private static IReservationService _reservationService = new ReservationService(reservationsRepository,stockBooksRepository);
        private static IFineService _fineService = new FineService(finesRepository);
        private static IBookService _bookService = new BookService(booksRepository);
        private static IPersonService _personService = new PersonService(personsRepository);
        private static IStockBookService _stockBookService = new StockBookService(stockBooksRepository);

        private static UserDTO _session;

        public static async Task Main(string[] args)
        {
            await MainMenuAsync();
        }
        private static async Task MainMenuAsync()
        {
            while (true)
            {
                Console.Clear();
                Messages.PrintHeader("BiblioUniversity");
                Console.WriteLine("1) Iniciar sesión");
                Console.WriteLine("2) Registrarse (Estudiante)");
                Console.WriteLine("0) Salir");
                Console.Write("Seleccione: ");
                var opt = Console.ReadLine();

                if (opt == "1") 
                    await LoginAsync();
                else if (opt == "2") 
                    await RegisterStudentFlowAsync();
                else if (opt == "0") 
                    break;
            }
        }

        #region Gestion de login
        private static async Task LoginAsync()
        {
            Console.Write("Usuario (matrícula): ");
            var username = Console.ReadLine()?.Trim() ?? string.Empty;
            Console.Write("Contraseña: ");
            var password = Riding.ReadHidden();

            var logged = await _userService.LoginAsync(username, password);

            if (logged == null)
            {
                Messages.Failure("Credenciales inválidas.");
                Messages.Pause();
                return;
            }

            _session = logged;

            switch (logged.Rol)
            {
                case Rol.Student:
                    await StudentMenuAsync();
                    break;
                case Rol.Librarian:
                    await LibrarianMenuAsync(isAdmin: false);
                    break;
                case Rol.Admin:
                    await AdminMenuAsync();
                    break;
                default:
                    Messages.Warning("Rol no reconocido.");
                    Messages.Pause();
                    break;
            }
        }
        private static async Task RegisterStudentFlowAsync()
        {
            Messages.PrintHeader("Registro de estudiante");

            var matricula = Riding.ReadRequired("Matrícula (solo números): ");
            if (!int.TryParse(matricula, out var enrollment) || enrollment < 20250000 || enrollment > 30000000)
            {
                Messages.Failure("La matrícula debe ser numérica y/o contar con un buen formato.");
                Messages.Pause();
                return;
            }

            var exists = await _userService.ConfirmUserExistsAsync(matricula);

            if (exists)
            {
                Messages.Failure("Ya existe un usuario con esa matrícula.");
                Messages.Pause();
                return;
            }

            var existsmat = context.Enrollments.FirstOrDefault(x => x.Code == matricula);
            if (existsmat == null)
            {
                Messages.Failure("Esa metrícula no esta en el sistema.");
                Messages.Pause();
                return;
            }

            var pass = Riding.ReadPasswordTwice();

            Console.WriteLine();
            Messages.PrintHeader("Datos personales");
            var name = Riding.ReadRequired("Nombre: ");
            var lastname = Riding.ReadRequired("Apellido: ");
            var phone = Riding.ReadRequired("Teléfono: ");
            var idCard = Riding.ReadRequired("Cédula: ");
            if (await _personService.ConfirmIdCard(idCard))
            {
                Messages.Failure("Ya existe un estudiante con esta cedula.");
                Messages.Pause();
                return;
            }
            var address = Riding.ReadRequired("Dirección: ");

            var enr = context.Enrollments.FirstOrDefault(x=> x.Code == enrollment.ToString());


            var person = await _personService.AddAsync(new CreatePersonDTO
            {
                Name = name,
                Lastname = lastname,
                Telephone = phone,
                Id_Card = idCard,
                Address = address
            });

            var student = await _studentService.AddAsync(new CreateStudentDTO
            {
                PersonId = person.Id,
                EnrollmentId = enr.Id
            });

            var user = await _userService.AddAsync(new CreateUserDTO
            {
                Username = matricula,
                Password = pass,
                Rol = Rol.Student,
                PersonId = student.Person.Id
            });

            Messages.Success($"Registro exitoso. ID Usuario: {user.Id} | ID Estudiante: {student.Id}");
            Messages.Pause();
        }
        #endregion

        #region Menus
        private static async Task StudentMenuAsync()
        {
            while (true)
            {
                Console.Clear();
                Messages.PrintHeader($"Estudiante - {_session.Username}");

                Console.WriteLine("1) Ver libros");
                Console.WriteLine("2) Reservar libro");
                Console.WriteLine("3) Mis reservas");
                Console.WriteLine("4) Mis multas");
                Console.WriteLine("5) Modificar mis datos");
                Console.WriteLine("0) Cerrar sesión");
                Console.Write("Seleccione: ");
                var opt = Console.ReadLine();

                if (opt == "1")
                    await ListBooksAsync();
                else if (opt == "2")
                    await CreateReservationAsync();
                else if (opt == "3")
                    await ListMyReservationsAsync();
                else if (opt == "4")
                    await ListMyFinesAsync();
                else if (opt == "5")
                    await UpdateMyPersonAsync();
                else if (opt == "0")
                    break;
            }
        }

        private static async Task LibrarianMenuAsync(bool isAdmin)
        {
            while (true)
            {
                Console.Clear();
                Messages.PrintHeader(isAdmin ? $"Administrador - {_session.Username} (Funciones de Bibliotecario)" : $"Bibliotecario - {_session.Username}");

                Console.WriteLine("1) Ver libros");
                Console.WriteLine("2) Crear libro");
                Console.WriteLine("3) Agregar stock de libro");
                Console.WriteLine("4) Multas");
                Console.WriteLine("5) Ver reservas PENDIENTES (aprobar / rechazar)");
                Console.WriteLine("6) Ver reservas APROBADAS");
                Console.WriteLine("7) Ver reservas RECHAZADAS");
                Console.WriteLine("8) Agregar datos adicionales");
                Console.WriteLine("0) Volver");
                Console.Write("Seleccione: ");
                var opt = Console.ReadLine();

                if (opt == "1") await ListBooksAsync();
                else if (opt == "2") await CreateBookAsync();
                else if (opt == "3")
                {
                    await ListBooksAsync();
                    await AddStockAsync();
                }
                else if (opt == "4") await FineByReservationAsync();
                else if (opt == "5") await ListAndValidateReservationsAsync();
                else if (opt == "6") await ListReservationsByStatusAsync(Reservation_status.Approved);
                else if (opt == "7") await ListReservationsByStatusAsync(Reservation_status.Rejected);
                else if (opt == "8") await AddDataForBooks();
                else if (opt == "0") break;
            }
        }

        private static async Task AdminMenuAsync()
        {
            while (true)
            {
                Console.Clear();
                Messages.PrintHeader($"Administrador - {_session.Username}");

                Console.WriteLine("— Funciones de Bibliotecario —");
                Console.WriteLine("1) Crear libro");
                Console.WriteLine("2) Agregar stock de libro");
                Console.WriteLine("3) Multas");
                Console.WriteLine("4) Ver reservas PENDIENTES (aprobar / rechazar)");
                Console.WriteLine("5) Ver reservas APROBADAS");
                Console.WriteLine("6) Ver reservas RECHAZADAS");
                Console.WriteLine("7 Agregar datos adicionales");
                Console.WriteLine();
                Console.WriteLine("— Funciones de Administrador —");
                Console.WriteLine("8) Crear Bibliotecario (Persona + Usuario + Licencia)");
                Console.WriteLine("9) Listar usuarios");
                Console.WriteLine("10) Eliminar usuario");
                Console.WriteLine("11) Agregar matricula");
                Console.WriteLine("0) Cerrar sesión");
                Console.Write("Seleccione: ");
                var opt = Console.ReadLine();

                if (opt == "1") await CreateBookAsync();
                else if (opt == "2")
                {
                    await ListBooksAsync();
                    await AddStockAsync();
                }
                else if (opt == "3") await FineByReservationAsync();
                else if (opt == "4") await ListAndValidateReservationsAsync();
                else if (opt == "5") await ListReservationsByStatusAsync(Reservation_status.Approved);
                else if (opt == "6") await ListReservationsByStatusAsync(Reservation_status.Rejected);
                else if (opt == "7") await AddDataForBooks();
                else if (opt == "8") await AdminCreateLibrarianFlowAsync();
                else if (opt == "9") await ListUsersAsync();
                else if (opt == "10") await DeleteUserAsync();
                else if (opt == "11") await AddEnrolment();
                else if (opt == "0") break;
            }
        }
        #endregion

        private static async Task ListBooksAsync()
        {
            var books = await _stockBookService.GetAllAsync();
            
            if (books.Count() == 0 || books == null) 
            { 
                Messages.Warning("No hay libros."); 
                Messages.Pause(); 
                return; 
            }

            Console.WriteLine();

            foreach (var b in books)
            {
                Console.WriteLine($"[{b.Book.Id}] {b.Book.Title} | Edición: {b.Book.Edition} | Páginas: {b.Book.Pages} | Cantidad disponible:{b.Available}");
            }
            Messages.Pause();
        }
        private static async Task ListBooksAsyncOnlyData(List<StockBookDTO> list)
        {
            foreach (var b in list)
            {
                Console.WriteLine($"[{b.Book.Id}] {b.Book.Title} | Edición: {b.Book.Edition} | Páginas: {b.Book.Pages} | Cantidad disponible:{b.Available}");
            }
        }

        private static async Task CreateReservationAsync()
        {
            while (true)
            {
                var meStudent = await GetLoggedStudentAsync();


                if (meStudent == null)
                {
                    Messages.Failure("No se encontró el estudiante vinculado al usuario actual.");
                    Messages.Pause();
                    return;
                }

                var books = await _stockBookService.GetAllAsync();

                if (books.Count() == 0)
                {
                    Messages.Warning("No hay libros.");
                    return;
                }

                ListBooksAsyncOnlyData(books.Select(x=>x).Where(x=>x.Available > 0).ToList());

                var bookId = Riding.ReadIntInList("ID libro:",books.Select(x=>x.Id).ToList());

                var b = books.Select(x => x).Where(x => x.Id == bookId).First();

                var qty = Riding.ReadInt("Cantidad de libros: ",1,b.Available);
                Console.Write("Descripción (opcional): ");
                var desc = Console.ReadLine();
                var request = Riding.ReadDatetime("Fecha de retiro:");
                var withdrawal = Riding.ReadDatetime("Fecha de entrega:",request);

                var dto = new CreateReservationDTO
                (
                    meStudent.Id,
                    bookId,
                    qty,
                    desc,
                    request,
                    withdrawal
                );

                var created = await _reservationService.AddAsync(dto);
                var msg = withdrawal.DayOfWeek != DayOfWeek.Saturday ? "Puedes pasar a buscarlo desde las 7:00 a.m. hasta las 4:00 p.m." : "Puedes pasar a buscarlo desde las 8:00 a.m. hasta las 2:00 p.m.";
                Messages.Success($"Reserva creada. ID: {created.Id}.\n{msg}");
                Messages.Pause();
                break;
            }
        }

        private static async Task ListMyReservationsAsync()
        {
            var meStudent = await GetLoggedStudentAsync();

            if (meStudent == null) 
            { 
                Messages.Failure("No se encontró el estudiante vinculado al usuario actual.");
                Messages.Pause(); 
                return; 
            }

            var all = await _reservationService.GetAllWithStudentBookAsync();
            var mine = all.Select(x=>x).Where(x=>x.StudentId == meStudent.Id).ToList();

            if (mine == null || mine.Count == 0) 
            { 
                Messages.Warning("No tienes reservas."); 
                Messages.Pause(); 
                return;
            }

            foreach (var r in mine)
            {
                Console.WriteLine($"[{r.Id}] Libro: {r.Book.Title} | Estado: {r.Status.ToString()} | Cant: {r.Quantify}S");
                Console.WriteLine($"Fecha de retiro: { r.Request_date.ToString("d")}");
                if (r.Withdrawal_date != null)
                    Console.WriteLine($"Fecha estimada de devolucion: {r.Withdrawal_date.ToString("d")}");
                if (r.Return_date != null)
                    Console.WriteLine($"Fecha de devolucion real: {r.Return_date.Value.ToString("d")}");
            }
            Messages.Pause();
        }

        private static async Task ListMyFinesAsync()
        {
            var meStudent = await GetLoggedStudentAsync();
            if (meStudent == null)
            { 
                Messages.Failure("No se encontró el estudiante vinculado al usuario actual."); 
                Messages.Pause(); 
                return; 
            }


            var fines = await _fineService.GetAllAsync();
            var myFines = fines?.Where(f =>
            {
                var res = f.Reservation;
                if (res != null)
                {
                    var sid = res.StudentId;
                    return sid == meStudent.Id;
                }

                var rid = f.ReservationId;

                if (rid != null)
                {
                    return false;
                }

                return false;

            }).ToList();

            if (myFines == null || myFines.Count == 0) 
            { 
                Messages.Warning("No tienes multas."); 
                Messages.Pause(); 
                return; 
            }

            foreach (var f in myFines)
            {
                Console.WriteLine($"[{f.Id}] {f.Description} | Monto: {f.Amaunt} | Estado: {f.Fine_Status.ToString()}");
            }
            Messages.Pause();
        }

        private static async Task UpdateMyPersonAsync()
        {
            var person = await _personService.GetByIdAsync(_session.PersonId);
            if (person == null) { Messages.Failure("No se encontró la persona asociada."); Messages.Pause(); return; }

            Console.WriteLine($"Nombre actual: {person.Name} {person.Lastname}");
            var tel = Riding.ReadRequired($"Teléfono ({person.Telephone}): ", allowEmpty: true);
            var addr = Riding.ReadRequired($"Dirección ({person.Address}): ", allowEmpty: true);

            if (!string.IsNullOrWhiteSpace(tel)) person.Telephone = tel;
            if (!string.IsNullOrWhiteSpace(addr)) person.Address = addr;

            await _personService.UpdateAsync(person);
            Messages.Success("Datos actualizados.");
            Messages.Pause();
        }

        private static async Task CreateBookAsync()
        {
            while (true)
            {
                try
                {
                    var Authors = context.Authors.ToList();
                    var Languages = context.Languages.ToList();
                    var Genres = context.Genres.ToList();

                    Messages.PrintHeader("Crear libro");
                    var title = Riding.ReadRequired("Título: ");
                    var edition = Riding.ReadRequired("Edición: ");
                    var pages = Riding.ReadInt("Páginas: ", min: 1);
                    var qty = Riding.ReadInt("Cantidad a agregar: ", min: 1);
                    var avqty = Riding.ReadInt("Cuantos quiere que esten disponibles?: ", 1, qty);
                    Console.WriteLine();
                    foreach (var a in Authors)
                    {
                        Console.WriteLine($"[{ a.Id}] {a.Name}");
                    }
                    var authorId = Riding.ReadIntInList("ID del Autor:", Authors.Select(x => x.Id).ToList());

                    Console.WriteLine();
                    foreach (var g in Genres)
                    {
                        Console.WriteLine($"[{g.Id}] {g.Name}");
                    }
                    var genreId = Riding.ReadIntInList("ID del Genero:", Genres.Select(x => x.Id).ToList());

                    Console.WriteLine();
                    foreach (var l in Languages)
                    {
                        Console.WriteLine($"[{l.Id}] {l.Name}");
                    }
                    var languageId = Riding.ReadIntInList("ID del idioma:", Languages.Select(x => x.Id).ToList());

                    var dto = new CreateBookDTO
                    {
                        Title = title,
                        Edition = edition,
                        Pages = pages,
                        Url_digital = "" ,
                        Url_image = "",
                        Authors = Authors.Where(x=>x.Id == authorId).ToList(),
                        Genres = Genres.Where(x => x.Id == genreId).ToList(),
                        Languages = Languages.Where(x=>x.Id == languageId).ToList()
                    };

                    var created = await _bookService.AddAsync(dto);

                    var stockbook = new CreateStockBookDTO {
                        BookId = created.Id,
                        Available = avqty,
                        Existing = qty
                    };

                    await _stockBookService.AddAsync(stockbook);

                    Messages.Success($"Libro creado. ID: {created.Id}, Cantidad existente {stockbook.Existing}, Cantidad dispoble {stockbook.Available}");
                    Messages.Pause();
                    break;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
        }

        private static async Task AddStockAsync()
        {
            Messages.PrintHeader("Agregar stock");
            var bookId = Riding.ReadInt("ID libro: ");
            var qty = Riding.ReadInt("Cantidad a agregar: ", min: 1);
            var avqty = Riding.ReadInt("Cuantos quiere que esten disponibles?",1,qty);

            var bookstock = context.Stocks.Select(x=>x).Where(x=>x.BookId == bookId).First();
            bookstock.Available = bookstock.Available + avqty;
            bookstock.Existing = bookstock.Existing + qty;
            var update = new StockBookDTO(bookstock);
            var created = await _stockBookService.UpdateAsync(update);
            Messages.Success($"Stock registrado. BookId: {update.BookId} | Existing: {update.Existing} | Available: {update.Available}");
            Messages.Pause();
        }

        private static async Task FineByReservationAsync()
        {
            Console.WriteLine("Multas elija que quiere hacer: \n1)Ver multas \n2)Registrar multas \n3)Cobrar multas");
            int choice = Riding.ReadInt("Eleccion: ", 1, 3);
            var fines = await _fineService.GetAllAsync();
            if (choice == 1)
            {
                if (fines.Count() == 0)
                {
                    Messages.Warning("No hay multas.");
                    Messages.Pause();
                    return;
                }

                Messages.PrintHeader("Todas las Multas");
                foreach (var f in fines)
                {
                    Console.WriteLine($"[{f.Id}] Matricula: {f.Reservation.Student.Enrollment.Code} | Status: {f.Fine_Status} | Monto: {f.Amaunt}");
                    Console.WriteLine($"Motivo: [{f.Description}]");
                }
                Messages.Pause();
            }
            if (choice == 2)
            {
                Messages.PrintHeader("Registrar Multa");
                var list = await _reservationService.GetAllWithStudentBookAsync();

                if (list.Count() == 0)
                {
                    Messages.Warning("No hay reservas.");
                    Messages.Pause();
                    return;
                }

                foreach (var f in list)
                {
                    if(fines.Where(x=>x.ReservationId == f.Id).FirstOrDefault() != null)
                    {
                        continue;
                    }
                    string matricula = f.Student.Enrollment.Code;
                    Console.WriteLine($"[{f.Id}] Matricula: {matricula}| Libro: {f.Book.Title}| Cantidad: {f.Quantify} | Motivo: {f.Description}");
                    Console.WriteLine($"Fecha de retiro: {f.Request_date.ToString("d")}");
                    if (f.Withdrawal_date != null)
                        Console.WriteLine($"Fecha estimada de devolucion: {f.Withdrawal_date.ToString("d")}");
                    if (f.Return_date != null)
                        Console.WriteLine($"Fecha de devolucion real: {f.Return_date.Value.ToString("d")}");

                }

                var reservationId = Riding.ReadInt("ID de reserva: ");
                var amount = Riding.ReadInt("Monto (entero): ", 1);
                var desc = Riding.ReadRequired("Motivo: ");

                var dto = new CreateFineDTO
                {
                    ReservationId = reservationId,
                    Amaunt = amount,
                    Description = desc,
                    Fine_Status = Fine_status.Pending
                };

                var created = await _fineService.AddAsync(dto);
                Messages.Success($"Multa creada. ID: {created.Id}");
                Messages.Pause();
            }
            if (choice == 3)
            {
                Messages.PrintHeader("Multas por cobrar");
                var list = fines.Where(x => x.Fine_Status == Fine_status.Pending);

                if (list.Count() == 0)
                {
                    Messages.Warning("No hay multas pendientes");
                    Messages.Pause();
                    return;
                }

                foreach (var f in list)
                {
                    Console.WriteLine($"[{f.Id}] Matricula: {f.Reservation.Student.Enrollment.Code} | Motivo: {f.Description} | Monto: {f.Amaunt}");
                }
                var fineid = Riding.ReadIntInList("Multa: ",list.Select(x=>x.Id).ToList());

                var fine = list.Where(x=> x.Id == fineid).FirstOrDefault();
                fine.Fine_Status = Fine_status.Paid;
                await _fineService.UpdateAsync(fine);

                Messages.Success("Se pago la multa.");
                Messages.Pause();
            }
        }

        private static async Task ListAndValidateReservationsAsync()
        {
            var all = await _reservationService.GetAllWithStudentBookAsync();
            var list = all.Select(x=>x).Where(x=>x.Status == Reservation_status.Pending).ToList();

            if (list == null || list.Count == 0)
            {
                Messages.Warning($"No hay reservas con estado {Reservation_status.Pending.ToString()}.");
                Messages.Pause();
                return;
            }

            Console.WriteLine();

            foreach (var r in list)
            {
                var title = r.Book.Title;
                var studentName = r.Student.Person.Name;
                
                Console.WriteLine($"[{r.Id}] Libro: {title} | Alumno: {studentName} | Cant: {r.Quantify} | Status: {r.Status.ToString()}");
                Console.WriteLine($"Motivo: {r.Description}");
                string msg = $"Fecha de retiro: {r.Request_date.ToString("d")}";
                if (r.Withdrawal_date != null)
                {
                    msg += $" | Fecha estimada de devolucion: {r.Withdrawal_date.ToString("d")}";
                }
                if (r.Return_date != null)
                {
                    msg += $"Fecha de devolucion real: {r.Return_date.Value.ToString("d")}";
                }
                Console.WriteLine(msg+"\n");
            }

            var listid = list.Select(x => x.Id).ToList();
            Console.WriteLine();

            int choise = Riding.ReadInt("Presione 1 para Aprobar y presione 2 para Rechazar: ", 1, 2);
   
            if (choise == 1)
            {
                int approveId = Riding.ReadIntInList("ID a APROBAR: ", listid);
                await UpdateReservationStatusAsync(approveId, Reservation_status.Approved);
                Messages.Success("Reserva aprobada.");
            }
           
            if (choise == 2)
            {
                int rejectId = Riding.ReadIntInList("ID a APROBAR: ", listid);
                await UpdateReservationStatusAsync(rejectId, Reservation_status.Rejected);
                Messages.Success("Reserva rechazada.");
            }

            Messages.Pause();
        }

        private static async Task ListReservationsByStatusAsync(Reservation_status status)
        {
            var all = await _reservationService.GetAllWithStudentBookAsync();
            var list = all?.Where(r => r.Status == status).ToList();

            if (list == null || list.Count == 0)
            {
                Messages.Warning($"No hay reservas con estado {status}.");
                Messages.Pause();
                return;
            }

            foreach (var r in list)
            {
                var title = r.Book.Title;
                var studentName = r.Student.Person.Name;
                Console.WriteLine($"[{r.Id}] Libro: {title} | Alumno: {studentName} | Cant: {r.Quantify}");
            }
            Messages.Pause();
        }

        private static async Task UpdateReservationStatusAsync(int reservationId, Reservation_status newStatus)
        {
            var current = await _reservationService.GetByIdWithStudentBookAsync(reservationId);
            if (current == null) 
            { 
                Messages.Failure("Reserva no encontrada."); 
                return; 
            }

            current.Status = newStatus;
            await _reservationService.UpdateAsync(current);
        }

        private static async Task AddDataForBooks()
        {
            while (true) 
            {
                Messages.PrintHeader("Datos adicionales");
                Console.WriteLine("1) Agregar autores");
                Console.WriteLine("2) Agregar lenguajes");
                Console.WriteLine("3) Agregar generos");

                int choice = Riding.ReadInt("Ingresa la operacion que quieres: ",1,3);
                if (choice == 1)
                {
                    var listAuthors = context.Authors.ToList();
                    var listid = listAuthors.Select(x => x.Id).ToList();
                    Console.WriteLine("Estos son los autores presentes: ");
                    foreach(var entity in listAuthors)
                    {
                        Console.WriteLine($"{entity.Name}");
                    }

                    Console.WriteLine("Agrega un autor que no este presente aca:");
                    string value = Riding.ReadRequired("Nombre: ");
                    string convalue = value.ToUpper().Trim();
                    bool confirm = listAuthors.Select(x => x.Name.ToUpper().Trim()).ToList().Contains(value);
                    if(confirm)
                    {
                        Messages.Warning("Ese autor ya existe");
                        continue;
                    }

                    context.Authors.Add(new Author(0,value));
                    context.SaveChanges();
                    Messages.Success($"Ya se creo el autor {value}");
                    Messages.Pause();
                    break;
                }

                if (choice == 2)
                {
                    var listLanguages = context.Languages.ToList();
                    var listid = listLanguages.Select(x => x.Id).ToList();
                    Console.WriteLine("Estos son los idiomas presentes: ");
                    foreach (var entity in listLanguages)
                    {
                        Console.WriteLine($"{entity.Name}");
                    }
                    Console.WriteLine("Agrega un idioma que no este presente aca:");
                    string value = Riding.ReadRequired("Idioma: ");
                    string convalue = value.ToUpper().Trim();
                    bool confirm = listLanguages.Select(x => x.Name.ToUpper().Trim()).ToList().Contains(value);
                    if (confirm)
                    {
                        Messages.Warning("Ese idioma ya existe");
                        continue;
                    }

                    context.Languages.Add(new Language(0, value));
                    context.SaveChanges();
                    Messages.Success($"Ya se creo el idioma {value}");
                    Messages.Pause();
                    break;
                }

                if (choice == 3)
                {
                    var listGenres = context.Genres.ToList();
                    var listid = listGenres.Select(x => x.Id).ToList();
                    Console.WriteLine("Estos son los generos presentes: ");
                    foreach (var entity in listGenres)
                    {
                        Console.WriteLine($"{entity.Name}");
                    }
                    Console.WriteLine("Agrega un genero que no este presente aca:");
                    string value = Riding.ReadRequired("Genero: ");
                    string convalue = value.ToUpper().Trim();
                    bool confirm = listGenres.Select(x => x.Name.ToUpper().Trim()).ToList().Contains(value);
                    if (confirm)
                    {
                        Messages.Warning("Ese genero ya existe");
                        continue;
                    }

                    context.Genres.Add(new Genre(0, value));
                    context.SaveChanges();
                    Messages.Success($"Ya se creo el genero {value}");
                    Messages.Pause();
                    break;
                }
            }
        }
        private static async Task AdminCreateLibrarianFlowAsync()
        {
            Messages.PrintHeader("Crear Bibliotecario");

            var name = Riding.ReadRequired("Nombre: ");
            var lastname = Riding.ReadRequired("Apellido: ");
            var phone = Riding.ReadRequired("Teléfono: ");
            var idCard = Riding.ReadRequired("Cédula: ");
            var address = Riding.ReadRequired("Dirección: ");

            var person = await _personService.AddAsync(new CreatePersonDTO
            {
                Name = name,
                Lastname = lastname,
                Telephone = phone,
                Id_Card = idCard,
                Address = address
            });

            var license = Riding.ReadRequired("Licencia: ");
            var librarian = await _librarianService.AddAsync(new CreateLibrarianDTO
            {
                PersonId = person.Id,
                License = license
            });

            var password = Riding.ReadPasswordTwice();
            var user = await _userService.AddAsync(new CreateUserDTO
            {
                Username = license,
                Password = password,
                Rol = Rol.Librarian,
                PersonId = person.Id
            });

            Messages.Success($"Bibliotecario creado. ID Librarian: {librarian.Id} | ID Usuario: {user.Id}");
            Messages.Pause();
        }
        private static async Task AddEnrolment()
        {
            while (true)
            {
                var listiEnrollment = context.Enrollments.ToList();

                Console.WriteLine("Estos son los autores presentes: ");
                foreach (var entity in listiEnrollment)
                {
                    Console.WriteLine($"{entity.Code}");
                }

                Console.WriteLine("Agrega una matricula que no este presente aca:");
                int value = Riding.ReadInt("Codigo: ",20250001,30000001);

                bool confirm = listiEnrollment.Select(x => x.Code).ToList().Contains(value.ToString());

                if (confirm)
                {
                    Messages.Warning("Esa matricula ya existe");
                    continue;
                }

                context.Enrollments.Add(new Enrollment(0, value.ToString()));
                context.SaveChanges();
                Messages.Success($"Ya se creo la matricula {value}");
                Messages.Pause();
                break;
            }
        }
        private static async Task ListUsersAsync()
        {
            var users = await _userService.GetAllAsync();
            foreach (var u in users)
            {
                Console.WriteLine($"[{u.Id}] {u.Username} - Rol: {u.Rol} - Persona: {u.PersonId}");
            }
            Messages.Pause();
        }
        private static async Task DeleteUserAsync()
        {
            var users = await _userService.GetAllAsync();
            foreach (var u in users)
            {
                Console.WriteLine($"[{u.Id}] {u.Username} - Rol: {u.Rol} - Persona: {u.PersonId}");
            }
            var id = Riding.ReadInt("ID de usuario a eliminar: ", min: 1);
            await _userService.DeleteAsync(id);
            Messages.Success("Usuario eliminado.");
            Messages.Pause();
        }

        private static async Task<StudentDTO> GetLoggedStudentAsync()
        {
            var all = await _studentService.GetAllAsync();
            return all.First(s => s.PersonId == _session.PersonId);
        }

    }
}