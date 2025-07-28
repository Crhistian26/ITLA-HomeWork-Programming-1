using MedicalApp.Domain;
using MedicalApp.Domain.Entitys;
using MedicalApp.Domain.Enums;
using MedicalApp.Domain.Exceptions;
using MedicalApp.Persistence;
using MedicalApp.Persistence.Migrations;
using MedicalApp.Persistence.Repositories;
using MedicalApp.Services.Services;
using MedicalApp.Visual.Views;
using MedicalApp.Visual.Views.Principal_Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Xml.Schema;

namespace MedicalApp.Visual
{
    internal class Program
    {
        static User user;
        static InputData inputs = new InputData();
        static MedicalContext _context = new MedicalContext(new DbContextOptionsBuilder<MedicalContext>().Options);
        static GeneralViews _generalView = new GeneralViews(_context);
                
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
            User f = _context.Users.Select(a=>a).First();
            _context = new MedicalContext(new DbContextOptionsBuilder<MedicalContext>().Options, f);


            User a = _context.Users.Select(a => a).Where(a=> a.Id == 7).First();
            _context.Users.Remove(a);
            _context.SaveChanges();
            Console.ForegroundColor= ConsoleColor.White;

            user = _generalView.Login();

            bool cont = false;
            do
            {
                

                if(user.Rols.Contains(Rol.Administrador) && user.Rols.Contains(Rol.Doctor))
                {
                    new LeonardoDaVinciView(_context).Main(args);
                }

                if(user.Rols.Contains(Rol.Administrador))
                {
                    new AdminView(_context).Main(args);
                }

                if(user.Rols.Contains(Rol.Doctor))
                {
                    new DoctorView(_context).Main(args);
                }

                if(user.Rols == null)
                {
                    Console.WriteLine("Este usuario no tiene roles en el sistema.");
                }
                cont = FinishView("Gracias por usar nuestro sistema de consultas");
                continue;
            } while (cont);
        }
    }
}



























//⠀⠀⠀⠀⠀⠀⠀⠈⠀⠀⠀⠀⠀⠀⠀⠈⠈⠉⠉⠈⠈⠈⠉⠉⠉⠉⠉⠉⠉⠉⠙⠻⣄⠉⠉⠉⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠓⣄⠀⠀⢀⠀⢀⣀⣤⠄⠀⠀⠀⠀⠀⠀⠀
//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢷⣉⣩⣤⠴⠶⠶⠒⠛⠛⠀⠀⠀⠀⠀
//⠀⠀⠀⠀⠀⠀⠀⠀⣴⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⣧⠤⠶⠒⠚⠋⠉⠀⠀⠀⠀⠀⠀⠀
//⠀⠀⠀⠀⠀⠀⢀⣾⡍⠀⠀⠀⠀⠀⠀⠀⠀⢠⣾⣫⣭⣷⠶⢶⣤⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
//⠶⠶⠖⠚⠛⠛⣹⠏⠀⠀⠀⠀⠀⠀⠀⠀⠴⠛⠛⠉⡁⠀⠀⠙⠻⣿⣷⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⢹⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
//⠀⠀⠀⠀⠀⢠⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣿⣿⡷⠷⢿⣦⣤⣈⡙⢿⣿⢆⣴⣤⡄⠀⠀⠀⠀⢸⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
//⠀⠀⣠⣤⡀⣸⡄⠀⠀⠀⠀⠀⠀⠀⢀⣤⣿⣿⣟⣩⣤⣴⣤⣌⣿⣿⣿⣦⣹⣿⢁⣿⣿⣄⣀⡀⠀⢸⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
//⠀⢠⣿⠋⠻⢿⡁⠀⠀⠀⠀⠀⠀⠀⠀⢸⡿⠿⠛⢦⣽⣿⣿⢻⣿⣿⣿⣿⠋⠁⠘⣿⣿⣿⣿⣿⣿⣼⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
//⠀⢸⣿⠁⠀⠀⠙⠆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠒⠿⣿⣯⣼⣿⡿⠟⠃⠀⠀⠀⣿⣿⣿⣿⣿⡛⣿⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
//⠀⢸⣧⣴⣿⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣺⠟⠃⠀⠀⠀⠀⠀⠀⠙⣿⣿⣿⣿⣿⣿⢁⣀⣀⣀⣀⣀⣠⣀⣀⢀⢀⢀
//⠀⠀⢿⠿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⡆⠙⠛⠛⠙⢻⣶⣶⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿
//⣿⣿⡇⠀⠘⠃⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡞⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
//⡟⢿⣿⣆⠀⣸⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢄⡼⠁⢀⣀⡀⠀⠀⠀⣦⣄⠀⣠⡄⣸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
//⣷⣬⢻⣿⡿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣧⣰⣿⡿⠿⠦⢤⣴⣿⣿⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
//⣿⣿⣸⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠛⠛⠛⠒⣿⣿⣿⡿⠟⠹⣼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
//⣿⠸⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⡖⠀⢠⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
//⡿⣾⣿⣸⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣆⣀⣀⣤⣴⣶⣶⣾⣿⣷⣦⣴⣼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
//⡇⣿⣿⡛⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⢾⡟⠛⠛⠻⠛⠛⠛⠿⠿⠿⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
//⠓⢁⣬⣿⠇⠀⠀⠀⠀⠀⢠⡀⠀⠀⠀⠀⠀⢰⡿⣻⠇⠀⠀⠀⠀⠀⣠⣶⣶⣶⣶⣿⣿⡿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
//⢐⣯⠞⠁⠀⠀⠀⠀⠀⠀⣄⠱⣄⠀⠀⠀⠀⠸⡧⠟⠆⠀⠀⠀⠀⠘⠿⢿⠿⠿⣿⡿⣿⠃⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
//⡾⠃⠀⠀⠀⠀⠀⠀⠀⠀⠘⢦⡈⠂⠀⠑⢄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢠⣿⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠒⡄⠀⠀⠑⠄⠀⠀⠀⠀⠀⠀⠀⢀⣠⣤⣦⣦⣼⡏⠳⣜⢿⠻⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠀⠀⠀⢠⣷⣦⣤⣀⣀⣀⣴⣿⣿⣿⣿⣿⡿⠻⠆⠸⣎⣧⠀⠈⠙⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿
//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣄⠀⠀⠀⣸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠁⣠⡄⠀⣿⢹⡇⢸⡀⠀⠈⠻⢿⣿⣿⣿⣿⣿⣿



//No hay mas codigo mi estimado, esto es todo
