using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.Visual
{
    public class InputData
    {
        private ConsoleColor _color = Console.ForegroundColor;
        public InputData() { }

        public void ColorError()
        {
            _color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
        }

        public void ColorNormal()
        {
            Console.ForegroundColor = _color;
        }

        public string GetString(string petition)
        {
            while (true)
            {
                _color = Console.ForegroundColor;
                Console.WriteLine(petition);
                string s = Console.ReadLine();

                if (s.Trim() == "")
                {
                    ColorError();
                    Console.WriteLine("\nPorfavor no puedes dejar vacio este campo.\nPresiona una tecla para continuar.");
                    Console.ReadKey();
                    ColorNormal();
                    continue;
                }

                ColorNormal();
                return s;
            }
        }

        public string GetEmail(string petition)
        {
            _color = Console.ForegroundColor;
            while (true)
            {
                ColorNormal();
                Console.WriteLine(petition);
                string s = Console.ReadLine();

                if (s.Trim() == "")
                {
                    ColorError();
                    Console.WriteLine("\nPorfavor no puedes dejar vacio este campo.\nPresiona una tecla para continuar.");
                    Console.ReadKey();
                    ColorNormal();
                    continue;
                }

                if(!s.Trim().Contains("@"))
                {
                    ColorError();
                    Console.WriteLine("\nPorfavor debe ingresar un correo valido (uno que tenga @).");
                    Console.ReadKey();
                    ColorNormal();
                    continue;
                }


                ColorNormal();
                return s;
            }
        }
        public int GetInt(string petition)
        {
            _color = Console.ForegroundColor;
            while (true)
            {
                ColorNormal();
                Console.WriteLine(petition);
                string s = Console.ReadLine();

                if (s.Trim() == "")
                {
                    ColorError();
                    Console.WriteLine("\nPorfavor no puedes dejar vacio este campo.\nPresiona una tecla para continuar.");
                    Console.ReadKey();
                    ColorNormal();
                    continue;
                }

                if (!int.TryParse(s, out int value))
                {
                    ColorError();
                    Console.WriteLine("\nPorfavor no puedes poner texto en este campo.\nPresiona una tecla para continuar.");
                    Console.ReadKey();
                    ColorNormal();
                    continue;
                }

                ColorNormal();
                return Convert.ToInt32(s);
            }
        }
        public int GetInt(string petition, int length)
        {
            _color = Console.ForegroundColor;
            while (true)
            {
                ColorNormal();
                Console.WriteLine(petition);
                string s = Console.ReadLine();

                if (s.Trim() == "")
                {
                    ColorError();
                    Console.WriteLine("\nPorfavor no puedes dejar vacio este campo.\nPresiona una tecla para continuar.");
                    Console.ReadKey();
                    ColorNormal();
                    continue;
                }

                if (!int.TryParse(s, out int value))
                {
                    ColorError();
                    Console.WriteLine("\nPorfavor no puedes poner texto en este campo.\nPresiona una tecla para continuar.");
                    Console.ReadKey();
                    ColorNormal();
                    continue;
                }

                if (value > length || value < 1)
                {
                    ColorError();
                    Console.WriteLine("\nPorfavor debes ingresar un numero que este dentro de el rango.\nPresiona una tecla para continuar.");
                    Console.ReadKey();
                    ColorNormal();
                    continue;
                }

                ColorNormal();
                return Convert.ToInt32(s);
            }
        }

        public string GetPhoneNumber(string petition)
        {
            _color = Console.ForegroundColor;
            while (true)
            {
                ColorNormal();
                Console.WriteLine(petition);
                string s = Console.ReadLine();

                if (s.Trim() == "")
                {
                    ColorError();
                    Console.WriteLine("\nPorfavor no puedes dejar vacio este campo.\nPresiona una tecla para continuar.");
                    Console.ReadKey();
                    ColorNormal();
                    continue;
                }

                if (!long.TryParse(s, out long value))
                {
                    ColorError();
                    Console.WriteLine("\nPorfavor no puedes poner texto en este campo.\nPresiona una tecla para continuar.");
                    Console.ReadKey();
                    ColorNormal();
                    continue;
                }

                if (value < 0)
                {
                    ColorError();
                    Console.WriteLine("\nPorfavor no puedes poner numeros negativos.\nPresiona una tecla para continuar.");
                    Console.ReadKey();
                    ColorNormal();
                    continue;
                }

                if (value < 8091111111)
                {
                    ColorError();
                    Console.WriteLine("\nPorfavor no puedes poner numeros invalidos.\nPresiona una tecla para continuar.");
                    Console.ReadKey();
                    ColorNormal();
                    continue;
                }

                ColorNormal();
                return s;
            }
        }

        public bool GetBool(string petition)
        {
            _color = Console.ForegroundColor;
            while (true)
            {
                ColorNormal();
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
                    ColorError();
                    Console.WriteLine("\nPorfavor ingresa S o N en mayuscula o minuscula, no se acepta otro valor al asignar el campo.");
                    ColorNormal();
                    continue;
                }
            }
        }
    }
}
