using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Consola
{
    public class Messages
    {
        public static void PrintHeader(string title)
        {
            Console.WriteLine(new string('=', Math.Max(6, title.Length + 4)));
            Console.WriteLine($"  {title}");
            Console.WriteLine(new string('=', Math.Max(6, title.Length + 4)));
        }

        public static void Success(string msg)
        {
            ConsoleColor c = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{msg}");
            Console.ForegroundColor = c;
        }
        public static void Failure(string msg)
        {
            ConsoleColor c = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{msg}");
            Console.ForegroundColor = c;
        }
        public static void Warning(string msg)
        {
            ConsoleColor c = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{msg}");
            Console.ForegroundColor = c;
        }
        public static void Pause()
        {
            Console.WriteLine();
            Console.Write("Presione ENTER para continuar...");
            Console.ReadLine();
        }
    }
}
