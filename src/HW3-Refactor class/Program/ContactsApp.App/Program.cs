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

        #region Methods for get data
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

        static string GetString(string petition)
        {
            while (true)
            {
                Console.WriteLine(petition);
                string s = Console.ReadLine();

                if (s.Trim() == "")
                {
                    Console.WriteLine("\nPorfavor no puedes dejar vacio este campo.\nPresiona una tecla para continuar.");
                    Console.ReadKey();
                    continue;
                }

                return s;
            }
        }
        static int GetInt(string petition)
        {
            while (true)
            {
                Console.WriteLine(petition);
                string s = Console.ReadLine();

                if (s.Trim() == "")
                {
                    Console.WriteLine("\nPorfavor no puedes dejar vacio este campo.\nPresiona una tecla para continuar.");
                    Console.ReadKey();
                    continue;
                }

                if (!int.TryParse(s, out int value))
                {
                    Console.WriteLine("\nPorfavor no puedes poner texto en este campo.\nPresiona una tecla para continuar.");
                    Console.ReadKey();
                    continue;
                }

                return Convert.ToInt32(s);
            }
        }
        static int GetInt(string petition, int length)
        {
            while (true)
            {
                Console.WriteLine(petition);
                string s = Console.ReadLine();

                if (s.Trim() == "")
                {
                    Console.WriteLine("\nPorfavor no puedes dejar vacio este campo.\nPresiona una tecla para continuar.");
                    Console.ReadKey();
                    continue;
                }

                if (!int.TryParse(s, out int value))
                {
                    Console.WriteLine("\nPorfavor no puedes poner texto en este campo.\nPresiona una tecla para continuar.");
                    Console.ReadKey();
                    continue;
                }

                if (value > length || value < 1)
                {
                    Console.WriteLine("\nPorfavor debes ingresar un numero que este dentro de el rango.\nPresiona una tecla para continuar.");
                    Console.ReadKey();
                    continue;
                }
                return Convert.ToInt32(s);
            }
        }

        static string GetPhoneNumber(string petition)
        {
            while (true)
            {
                Console.WriteLine(petition);
                string s = Console.ReadLine();

                if (s.Trim() == "")
                {
                    Console.WriteLine("\nPorfavor no puedes dejar vacio este campo.\nPresiona una tecla para continuar.");
                    Console.ReadKey();
                    continue;
                }

                if (!long.TryParse(s, out long value))
                {
                    Console.WriteLine("\nPorfavor no puedes poner texto en este campo.\nPresiona una tecla para continuar.");
                    Console.ReadKey();
                    continue;
                }

                if (value < 0)
                {
                    Console.WriteLine("\nPorfavor no puedes poner numeros negativos.\nPresiona una tecla para continuar.");
                    Console.ReadKey();
                    continue;
                }

                if (value < 1000000)
                {
                    Console.WriteLine("\nPorfavor no puedes poner numeros invalidos.\nPresiona una tecla para continuar.");
                    Console.ReadKey();
                    continue;
                }

                return s;
            }
        }

        static bool GetBool(string petition)
        {
            while (true)
            {
                Console.WriteLine(petition);
                Console.Write("\nIngresa una S para SI y una N para NO: ");
                string s = Console.ReadLine();
                if (s.Trim().ToUpper() == "S")
                {
                    return true;
                }
                else if (s.Trim().ToUpper() == "N")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("\nPorfavor ingresa S o N en mayuscula o minuscula, no se acepta otro valor al asignar el campo.");
                }
            }
        }


        #endregion
        static void Main(string[] args)
        {
            bool resetMain = false;
            do
            {
                Console.Clear();
                int choicePresentation = PresentationApp();

                switch (choicePresentation)
                {
                    //Show Contacts
                    case 1:
                        StartView(ConsoleColor.Magenta, "Ver contactos.");
                        if (contacts.Count == 0)
                        {
                            Console.WriteLine("No tienes contactos registrados aun. \n\n");
                        }
                        else
                        {
                            for (int i = 0; i < contacts.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}){contacts[i].Name} {contacts[i].LastName}");
                            }
                        }

                        resetMain = FinishView("Gracias por ver los contactos");
                        break;


                    //Search Contact
                    case 2:
                        bool confirm = false;
                        int choiceContact;
                        do
                        {
                            StartView(ConsoleColor.DarkCyan, "Detalles de contacto.");
                            if (contacts.Count == 0)
                            {
                                Console.WriteLine("Lo sentimos esa opcion no esta disponible ya que no dispone de contactos todavia");

                                resetMain = FinishView("Gracias por ver los detalles.");
                                confirm = false;
                                continue;
                            }
                            else
                            {
                                for (int i = 0; i < contacts.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}){contacts[i].Name} {contacts[i].LastName}");
                                }
                            }

                            Console.WriteLine("Elige un numero para ver los detalles:");
                            string f = Console.ReadLine();

                            if (int.TryParse(f, out choiceContact) && choiceContact <= contacts.Count && choiceContact > 0)
                            {
                                Console.Clear();
                                Contact c = contacts[choiceContact - 1];
                                Console.WriteLine("Nombre: " + c.Name);
                                Console.WriteLine("Apellido: " + c.LastName);
                                Console.WriteLine("Numero: " + c.Phone);
                                Console.WriteLine("Direccion: " + c.Address);
                                Console.WriteLine("Correo: " + c.Email);
                                Console.WriteLine("Edad: " + c.Age);
                                if (c.BestFriends == true)
                                {
                                    Console.WriteLine("Es tu pana fiel.");
                                }
                                else
                                {
                                    Console.WriteLine("No es tu pana fiel");
                                }

                                resetMain = FinishView("Gracias por ver los detalles");
                                continue;
                            }

                            else
                            {
                                if (int.TryParse(f, out choiceContact))
                                {
                                    Console.WriteLine("Deberia de elegir un numero entre el rango de sus contactos.");
                                }
                                else
                                {
                                    Console.WriteLine("Deberia poner un valor numerico.");
                                }

                                Console.WriteLine("Presione cualquier tecla para continuar.");
                                Console.ReadKey();
                                confirm = true;
                                continue;
                            }
                        } while (confirm);
                        break;


                    //Add Contact
                    case 3:
                        StartView(ConsoleColor.DarkGreen, "Agregar contactos: ");
                        Console.WriteLine("Porfavor llena correctamente los campos solicitados: ");
                        string n = GetString("Ingresa el nombre: ");
                        string ln = GetString("Ingresa el apellido: ");
                        string p = GetPhoneNumber("Ingresa el numero: ");
                        string ad = GetString("Ingresa su direccion: ");
                        string em = GetString("Ingresa su EMAIL: ");
                        int ag = GetInt("Ingresa su edad: ");
                        bool bf = GetBool("El es pana fiel tuyo o no?");

                        Contact contact = new Contact(contacts.Count + 1, n, ln, p, ad, em, ag, bf);

                        contacts.Add(contact);

                        resetMain = FinishView("Gracias por agregar un contacto.");

                        break;
                    //Update Contact
                    case 4:
                        
                        break;
                    //Delete Contact
                    case 5:
                       
                        break;
                    //Close app
                    case 0:
                       
                        break;
                }
            } while (resetMain);
        }
    }
}
