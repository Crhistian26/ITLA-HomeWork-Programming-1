using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Consola
{
    public class Riding
    {
        public static string ReadRequired(string label, bool allowEmpty = false)
        {
            while (true)
            {
                Console.Write(label);

                var v = Console.ReadLine() ?? string.Empty;

                if (allowEmpty || !string.IsNullOrWhiteSpace(v))
                    return v;

                Console.WriteLine("Campo requerido.");
            }
        }

        public static int ReadInt(string label = null, int? min = null, int? max = null)
        {
            while (true)
            {
                if (!string.IsNullOrEmpty(label))
                    Console.Write(label);

                var s = Console.ReadLine();

                if (int.TryParse(s, out var n))
                {
                    if (min.HasValue && n < min.Value) 
                    { 
                        Console.WriteLine($"Debe ser ≥ {min.Value}."); 
                        continue; 
                    }
                    if (max.HasValue && n > max.Value) 
                    { 
                        Console.WriteLine($"Debe ser ≤ {max.Value}."); 
                        continue; 
                    }
                    return n;
                }
                Console.WriteLine("Ingrese un número válido.");
            }
        }

        public static int ReadIntInList(string label,List<int> list)
        {
            while (true)
            {

                Console.Write(label);

                var s = Console.ReadLine();

                if (int.TryParse(s, out var n) && list.FirstOrDefault(x=> x==n) != null)
                {
                    return n;
                }
                Console.WriteLine("Ingrese un número válido.");
            }
        }

        public static DateTime ReadDatetime(string label, DateTime? begin = null)
        {
            while (true)
            {
                Console.WriteLine(label);
                DateTime now = DateTime.Now;
                var y = ReadInt("Elige el año:",now.Year,DateTime.Now.Year + 2);
                var m = ReadInt("Elige el mes:",now.Month,12);
                var d = ReadInt("Elige el dia:",1,DateTime.DaysInMonth(y,m));
                DateTime date = new DateTime(y,m,d);

                if (date.DayOfWeek == DayOfWeek.Sunday )
                {
                    Messages.Warning("Debes de poner una fecha que no sea un domingo");
                    continue;
                }

                if (date < DateTime.Now)
                {
                    Messages.Warning("Debes de poner igual o mayor al dia de hoy");
                    continue;
                }

                if (begin != null)
                {
                    if (begin > date)
                    {
                        Messages.Warning("Debes elegir una fecha posterior al dia de retiro.");
                        continue;
                    }
                    return date;
                }

                return date;

            }
        }

        public static string ReadHidden()
        {
            var pass = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    pass = pass.Substring(0, pass.Length - 1);
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    pass += keyInfo.KeyChar;
                    Console.Write("*");
                }
            } while (key != ConsoleKey.Enter);

            Console.WriteLine();
            return pass;
        }

        public static string ReadPasswordTwice()
        {
            while (true)
            {
                Console.Write("Contraseña: ");
                var p1 = ReadHidden();

                Console.Write("Confirmar contraseña: ");
                var p2 = ReadHidden();

                if (p1 == p2) 
                    return p1;

                Console.WriteLine("Las contraseñas no coinciden. Intenta de nuevo.");
            }
        }
    }
}
