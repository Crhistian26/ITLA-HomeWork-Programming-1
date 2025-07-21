using MedicalApp.Domain;
using MedicalApp.Domain.Entitys;
using MedicalApp.Domain.Enums;
using MedicalApp.Domain.Exceptions;
using MedicalApp.Persistence;
using MedicalApp.Persistence.Migrations;
using MedicalApp.Persistence.Repositories;
using MedicalApp.Services.Services;
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
        static ConsultationRepository consultationRepository = new ConsultationRepository(context);
        static ConsultationService _consultationService = new ConsultationService(consultationRepository);

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
                Console.WriteLine("1)Citas medicas  2)Datos de pacientes  3)Datos de medicos  4)Registros  5)Cerrar la app");
                choice = inputs.GetInt("Elige a que proceso quieres ir: ", 5);
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
                        Console.WriteLine("Que quieres hacer con los registros?");
                        Console.WriteLine("1)Ver todos los registros del sistema  2)Ver todos los registros de un usuario  3)Volver atras");
                        choice = inputs.GetInt("Elige que quieres hacer: ", 3);
                        next = choice == 3 ? true  : false;


                        data.Item2 = choice;
                        next = false;
                        break;
                    case 5:
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
            
            #region Login
            int trys = 3;
            do
            {   
                string username = inputs.GetString("Ingrese su nombre de usuario: ");
                string password = inputs.GetString("Ingrese su contraseña: ");
                try
                {
                    user = _userService.Login(username, password);
                }
                catch(ExceptionServices ex)
                {
                    inputs.ColorError();
                    Console.WriteLine("\n"+ex.Message);
                    
                }
                finally { inputs.ColorNormal(); }
                
                if(user != null)
                {
                    break;
                }

                trys--;

            }while(trys > 0);

            if (trys == 0)
            {
                Console.WriteLine("Te bloqueamos la entrada al sistema por no tener un usuario");
                Console.ReadLine();
                Environment.Exit(0);
            }
            #endregion

            bool cont = false;

            do
            {
                (int, int) processChoice = BeginView();

                switch (processChoice)
                {
                    case (1, 1):
                        Console.WriteLine("Estas son las citas que tiene pendientes");
                        List<Consultation> cons = _consultationService.GetConsultationsPending();

                        if (cons == null || cons.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("No tienes consultas pendientes");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        }

                        foreach (var c in cons)
                        {
                            Console.WriteLine($"{c.Id}) Fecha: {c.Date} | Paciente: {c.Patient.Person.Name} {c.Patient.Person.Lastname} | Doctor: {c.Doctor.Person.Name} {c.Doctor.Person.Lastname}");
                        }


                        break;
                }
                cont = FinishView("Gracias por usar nuestro sistema de consultas");
                continue;
            } while (cont);
        }
    }
}
