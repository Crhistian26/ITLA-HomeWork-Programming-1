using MedicalApp.Domain;
using MedicalApp.Domain.Entitys;
using MedicalApp.Domain.Enums;
using MedicalApp.Domain.Exceptions;
using MedicalApp.Persistence;
using MedicalApp.Persistence.Migrations;
using MedicalApp.Persistence.Repositories;
using MedicalApp.Services.Services;
using MedicalApp.Visual.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Xml.Schema;

namespace MedicalApp.Visual
{
    internal class Program
    {
        static User user;
        static InputData inputs = new InputData();
        static MedicalContext context = new MedicalContext(new DbContextOptionsBuilder<MedicalContext>().Options, new User());
        static UserRepository userRepository = new UserRepository(context);
        static UserService _userService = new UserService(userRepository);
        static PersonRepository personRepository = new PersonRepository(context);
        static PersonService _personService = new PersonService(personRepository);
        static DoctorRepository doctorRepository = new DoctorRepository(context);
        static DoctorService _doctorService = new DoctorService(doctorRepository);
        static ConsultationRepository consultationRepository = new ConsultationRepository(context);
        static ConsultationService _consultationService = new ConsultationService(consultationRepository);

        static UserViews _userViews = new UserViews(inputs,_userService,_doctorService);
        static (int,int) BeginView()
        {
            var data = (0, 0);
            bool next = false;
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine($"Bienvenido a nuestra app medica {user.Username}");
                Console.WriteLine("Porfavor digame que proceso quieres trabajar: ");
                Console.WriteLine("1)Citas medicas  2)Datos de pacientes  3)Datos de medicos  4)Datos de usuarios  5)Registros  6)Cerrar la app");
                choice = inputs.GetInt("Elige a que proceso quieres ir: ", 6);
                data.Item1 = choice;
                Console.Clear();

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Que quieres hacer en el proceso de Citas medicas?");
                        Console.WriteLine("1)Atender citas agendadas  2)Atender citas no agendadas  3)Agendar una cita  4)Modificar fecha de una cita  5)Eliminar una cita  6)Volver atras");
                        choice = inputs.GetInt("Elige que quieres hacer: ", 6);

                        if (choice == 6) { next = true; continue; }

                        data.Item2 = choice;
                        next = false;
                        break;
                    case 2:
                        Console.WriteLine("Que quieres hacer con los datos de los pacientes?");
                        Console.WriteLine("1)Ver todos los pacientes registrados  2)Ver los datos de un paciente  3)Agregar un paciente  4)Modificar un paciente  5)Eliminar un paciente  6)Volver atras");
                        choice = inputs.GetInt("Elige que quieres hacer: ", 6);

                        if (choice == 6) { next = true; continue; }

                        data.Item2 = choice;
                        next = false;
                        break;
                    case 3:
                        Console.WriteLine("Que quieres hacer con los datos de los medicos?");
                        Console.WriteLine("1)Ver todos los medicos  2)Ver los datos de un medico  3)Agendar un medico  4)Modificar un medico  5)Eliminar un medico  6)Volver atras");
                        choice = inputs.GetInt("Elige que quieres hacer: ", 6);

                        if(choice == 6) { next = true; continue; }

                        data.Item2 = choice;
                        next = false;
                        break;
                    case 4:
                        Console.WriteLine("Que quieres hacer con los usuarios?");
                        Console.WriteLine("1)Ver todos los usuarios   2)Ver los detalles de un usuario   3)Agregar un usuario   4)Modificar un usuario   5)Eliminar un usuario   6)Volver atras");
                        choice = inputs.GetInt("Elige que quieres hacer: ", 6);

                        if (choice == 6) { next = true; continue; }

                        data.Item2 = choice;
                        next = false;
                        break;
                    case 5:
                        Console.WriteLine("Que quieres hacer con los registros?");
                        Console.WriteLine("1)Ver todos los registros del sistema  2)Ver todos los registros de un usuario  3)Volver atras");
                        choice = inputs.GetInt("Elige que quieres hacer: ", 3);
                        next = choice == 3 ? true  : false;


                        data.Item2 = choice;
                        next = false;
                        break;
                    case 6:
                        Console.WriteLine("Fue un placer ayudarle.");
                        Console.WriteLine("Presione cualquier tecla para cerrar la app");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;

                }
            } while (next);

            return data;
        }

        static bool FinishView(string finishMessage)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nQuieres seguir en la app o cerrarla?\nPresione el numero 0 para CERRAR y presionar cualquier otro numero o letra es para continuar en la app.");
                string a = Console.ReadLine();

                if (a.Trim() == "0")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(finishMessage);
                    Console.WriteLine("Presione cualquier otra tecla para cerrar el programa.");
                    Console.ReadKey();
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        static void Main(string[] args)
        {
            Console.ForegroundColor= ConsoleColor.White;

            //Person p = new Person("Julio", "Perez", "67898898670", "8097765654");
            //Person p1 = new Person("Maria", "Pereira", "67898898670", "8097765654");

            //_personService.AddPerson(p);
            //_personService.AddPerson(p1);

            //Doctor d = new Doctor(p, new List<Specialties>() { Specialties.Pediatra, Specialties.Cardiologo });
            //_doctorService.AddDoctor(d);

            //User u = new User(Rol.Doctor, "JP", "123", d);
            //User u1 = new User(Rol.Administrador, "Maria", "123", null);
            //_userService.AddUser(u);
            //_userService.AddUser(u1);


            user = _userViews.Login();

            bool cont = false;
            do
            {
                (int, int) processChoice = BeginView();

                switch (processChoice)
                {
                    case (1, 1):
                        
                        break;
                    case (4, 1):
                        _userViews.GetAllUsers();
                        break;
                    case (4, 2):
                        _userViews.GetUserByIDView();
                        break;
                    case (4, 3):
                        _userViews.AddUserView();
                        break;

                }
                cont = FinishView("Gracias por usar nuestro sistema de consultas");
                continue;
            } while (cont);
        }
    }
}
