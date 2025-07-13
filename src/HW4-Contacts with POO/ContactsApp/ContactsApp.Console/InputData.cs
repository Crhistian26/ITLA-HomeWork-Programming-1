using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Visual
{
    internal class InputData
    {
        public InputData() { }

        public string GetString(string petition)
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

        public int GetInt(string petition)
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
        public int GetInt(string petition, int length)
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

        public string GetPhoneNumber(string petition)
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

        public bool GetBool(string petition)
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
    }
}
