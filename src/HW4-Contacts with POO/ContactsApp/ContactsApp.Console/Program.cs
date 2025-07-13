using ContactsApp.Domain.Entitys;
using ContactsApp.Infraestructure.Interfaces;
using ContactsApp.Infraestructure.Repositorys;
using ContactsApp.Services.Interfaces;
using ContactsApp.Services.Services;

namespace ContactsApp.Visual
{
    internal class Program
    {
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
            IRepository<Contact> _contactRepository = new ContactRepository();
            IContactService _service = new ContactService(_contactRepository);
            InputData input = new InputData();

            bool resetMain = false;
            do
            {
                Console.Clear();
                int choicePresentation = PresentationApp();

                switch (choicePresentation)
                {
                    case 1:
                        {
                            List<Contact> contacts = _service.GetAllContacts();

                            StartView(ConsoleColor.Magenta, "Ver contactos.");
                            if (contacts.Count == 0)
                            {
                                Console.WriteLine("No tienes contactos registrados aun. \n\n");
                            }
                            else
                            {
                                for (int i = 0; i < contacts.Count; i++)
                                {
                                    Console.WriteLine($"{contacts[i].ID}){contacts[i].Name} {contacts[i].LastName}");
                                }
                            }

                            resetMain = FinishView("Gracias por ver los contactos");
                            break;
                        }

                    case 2:
                        {
                            List<Contact> contacts = _service.GetAllContacts();
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
                                        Console.WriteLine($"{contacts[i].ID}){contacts[i].Name} {contacts[i].LastName}");
                                    }
                                }

                                Console.WriteLine("Elige un numero para ver los detalles:");
                                string f = Console.ReadLine();

                                if (!int.TryParse(f, out choiceContact))
                                {
                                    Console.WriteLine("Deberia de poner datos numericos");
                                    Console.WriteLine("Presione cualquier tecla para continuar.");
                                    Console.ReadKey();
                                    confirm = true;
                                    continue;
                                }

                                choiceContact = Convert.ToInt32(f);

                                if (!_service.VerifyId(choiceContact))
                                {
                                    Console.WriteLine("Lo sentimos pero no existe un contacto con ese id");
                                    Console.WriteLine("Presione cualquier tecla para continuar.");
                                    Console.ReadKey();
                                    confirm = true;
                                    continue;
                                }

                                Console.Clear();
                                Contact c = _service.GetContact(choiceContact);
                                Console.WriteLine("Id: " + c.ID);
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
                               
                            } while (confirm);
                            break;
                        }
                    case 3:
                        try
                        {
                            StartView(ConsoleColor.DarkGreen, "Agregar contactos: ");
                            Console.WriteLine("Porfavor llena correctamente los campos solicitados: ");
                            string n = input.GetString("Ingresa el nombre: ");
                            string ln = input.GetString("Ingresa el apellido: ");
                            string p = input.GetPhoneNumber("Ingresa el numero: ");
                            string ad = input.GetString("Ingresa su direccion: ");
                            string em = input.GetString("Ingresa su EMAIL: ");
                            int ag = input.GetInt("Ingresa su edad: ");
                            bool bf = input.GetBool("El es pana fiel tuyo o no?");

                            Contact contact = new Contact(0, n, ln, p, ad, em, ag, bf);

                            _service.AddContact(contact);

                            resetMain = FinishView("Gracias por agregar un contacto.");

                            break;
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine($"Hubo un error en la aplicacion: {ex.Message}");
                            resetMain = FinishView("Aun quieres seguir?");
                            break;
                        }
                    case 4:
                        try
                        {
                            List<Contact> contacts = _service.GetAllContacts();
                            StartView(ConsoleColor.DarkCyan, "Modificar contactos: ");
                            if (contacts.Count == 0)
                            {
                                Console.WriteLine("No tienes contactos registrados aun asi que esta opcion no esta disponibles. \n\n");
                                resetMain = FinishView("Gracias por modificar contactos.");
                            }
                            else
                            {
                                int IdContact = 0;
                                for (int i = 0; i < contacts.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}){contacts[i].Name} {contacts[i].LastName}");
                                }
                                IdContact = input.GetInt("Porfavor ingresa el contacto a modificar: ", contacts.Count);
                                bool resetQuestion = false;
                                do
                                {
                                    Console.Clear();
                                    Console.WriteLine("Datos del contacto actual:");
                                    Contact c = contacts[IdContact - 1];
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


                                    Contact updateContact = contacts[IdContact - 1];

                                    Console.WriteLine("\nDime que quieres modificar: ");
                                    Console.WriteLine("1)Nombre   2)Apellido   3)Numero  4)Direccion   5)Correo   6)Edad   7)Si es pana fiel");
                                    int choice = input.GetInt("Ingresa tu decision: ", 7);

                                    if (choice == 1)
                                    {
                                        Console.WriteLine("Su nombre actual es: " + updateContact.Name);
                                        string name = input.GetString("Ingresa su nuevo nombre: ");
                                        updateContact.Name = name;
                                        contacts[IdContact - 1] = updateContact;
                                        resetQuestion = input.GetBool("Quieres seguir modificando el contacto?");
                                        continue;
                                    }

                                    if (choice == 2)
                                    {
                                        Console.WriteLine("Su apellido actual es: " + updateContact.LastName);
                                        string lastname = input.GetString("Ingresa su nuevo apellido: ");
                                        updateContact.LastName = lastname;
                                        contacts[IdContact - 1] = updateContact;
                                        resetQuestion = input.GetBool("Quieres seguir modificando el contacto?");
                                        continue;
                                    }

                                    if (choice == 3)
                                    {
                                        Console.WriteLine("Su numero actual es: " + updateContact.Phone);
                                        string phone = input.GetPhoneNumber("Ingresa su nuevo numero: ");
                                        updateContact.Phone = phone;
                                        contacts[IdContact - 1] = updateContact;
                                        resetQuestion = input.GetBool("Quieres seguir modificando el contacto?");
                                        continue;
                                    }

                                    if (choice == 4)
                                    {
                                        Console.WriteLine("Su direccion actual es: " + updateContact.Address);
                                        string address = input.GetString("Ingresa su nueva direccion: ");
                                        updateContact.Address = address;
                                        contacts[IdContact - 1] = updateContact;
                                        resetQuestion = input.GetBool("Quieres seguir modificando el contacto?");
                                        continue;
                                    }

                                    if (choice == 5)
                                    {
                                        Console.WriteLine("Su correo actual es: " + updateContact.Email);
                                        string email = input.GetString("Ingresa su nuevo correo: ");
                                        updateContact.Email = email;
                                        contacts[IdContact - 1] = updateContact;
                                        resetQuestion = input.GetBool("Quieres seguir modificando el contacto?");
                                        continue;
                                    }

                                    if (choice == 6)
                                    {
                                        Console.WriteLine("Su edad actual es: " + updateContact.Age);
                                        int age = input.GetInt("Ingresa su edad: ");
                                        updateContact.Age = age;
                                        contacts[IdContact - 1] = updateContact;
                                        resetQuestion = input.GetBool("Quieres seguir modificando el contacto?");
                                        continue;
                                    }

                                    if (choice == 7)
                                    {
                                        bool bestFriends = updateContact.BestFriends;
                                        string message = bestFriends ? "El es pana tuyo fiel" : "El es un pana normal";
                                        Console.WriteLine(message);
                                        bestFriends = input.GetBool("Es tu pana fiel? ");
                                        updateContact.BestFriends = bestFriends;
                                        contacts[IdContact - 1] = updateContact;
                                        resetQuestion = input.GetBool("Quieres seguir modificando el contacto?");
                                        continue;
                                    }
                                } while (resetQuestion);

                                resetMain = FinishView("Gracias por modificar los contactos");
                            }
                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Hubo un error en la aplicacion: {ex.Message}");
                            resetMain = FinishView("Aun quieres seguir?");
                            break;
                        }


                    case 5:
                        try
                        {

                            List<Contact> contacts = _service.GetAllContacts();
                            StartView(ConsoleColor.DarkRed, "Eliminar contacto: ");
                            if (contacts.Count == 0)
                            {
                                Console.WriteLine("No tienes contactos registrados aun asi que esta opcion no esta disponibles. \n\n");
                            }
                            else
                            {
                                int IdContact = 0;
                                for (int i = 0; i < contacts.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}){contacts[i].Name} {contacts[i].LastName}");
                                }
                                IdContact = input.GetInt("Porfavor ingresa el contacto a eliminar: ", contacts.Count);
                                bool confDelete = input.GetBool($"Estas seguro de eliminar el contacto {contacts[IdContact - 1].Name}?");

                                if (confDelete)
                                {
                                    contacts.Remove(contacts[IdContact - 1]);
                                }
                            }
                            resetMain = FinishView("Gracias por eliminar contactos.");
                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Hubo un error en la aplicacion: {ex.Message}");
                            resetMain = FinishView("Aun quieres seguir?");
                            break;
                        }
                    case 0:
                        bool choiceFinal = input.GetBool("Estas seguro de salir de la app?");
                        if (choiceFinal)
                        {
                            resetMain = false;
                        }
                        else
                        {
                            resetMain = true;
                        }
                        break;
                }
            } while (resetMain);
        }
    }
}
