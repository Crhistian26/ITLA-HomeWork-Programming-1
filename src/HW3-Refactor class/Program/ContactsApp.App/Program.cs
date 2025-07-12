using ContactsApp.App.Entitys;
using Microsoft.Win32.SafeHandles;
using System.Diagnostics;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

namespace ContactsApp.App
{
    internal class Program
    {
        static List<Contact> contacts = new List<Contact>()
        {
            new Contact(1,"Alberto","Gutierrez","8096785678","Los Alcarrizos","Alberto@gmail.com",21,true),
            new Contact(2,"Henrique","Carrasco","8490987685" ,"Federico Guzman","Carrasco@gmail.com",23,false)
        };

        #region Metodos para obtener datos
        static int PresentationApp()
        {
            int choice = 0; bool i = false;

            do
            {
                Console.WriteLine("Bienvenido a mi lista de Contactos\n");
                Console.WriteLine("1)Ver contactos.  2)Detalles de un contacto.  3)Agregar contacto.  4)Modificar un contacto.  5)Eliminar un contacto.");
                Console.WriteLine("0)Salir de la app\n");
                Console.Write("Elija entre las opciones disponibles: ");
                var f = Console.ReadLine();


                if (!int.TryParse(f, out choice))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\nDebe ser un valor numerico.\nPresiona una tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    i = true;
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                if (choice > 5 || choice < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\nDebe ser un valor numerico entre el rango de 0 a 5, lea las opciones.\nPresiona una tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    i = true;
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                choice = Convert.ToInt32(f);
                i = false;

            } while (i);

            return choice;
        }

        static void StartView(ConsoleColor color, string nameView)
        {
            Console.Clear();
            Console.ForegroundColor = color;
            Console.WriteLine(nameView + "\n");
        }
        static bool FinishView(string finishMessage)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nQuieres seguir en la app o cerrarla?\nPresione el numero 1 para seguir y presionar cualquier otro numero o letra es un no.");
                string a = Console.ReadLine();

                if (a.Trim() != "1")
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

        #endregion
        static void Main(string[] args)
        {
        }
    }
}
