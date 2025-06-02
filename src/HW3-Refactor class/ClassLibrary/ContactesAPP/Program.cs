using ClassLibrary;
using System.ComponentModel;
using System.Text.Json;


namespace ConsoleProgram
{
    internal class Program
    {
        static List<Contacte> Contactes = new List<Contacte>();
        static string Path = Directory.GetCurrentDirectory() + "\\contactes.txt";

        public static void SaveData()
        {
            string json = JsonSerializer.Serialize(Contactes);
            File.WriteAllText(Path, json);
        }

        public static void LoadData()
        {
            try
            {
                string json = File.ReadAllText(Path);
                Contactes = JsonSerializer.Deserialize<List<Contacte>>(json);
            }
            catch
            { 
                File.WriteAllText(Path, JsonSerializer.Serialize(Contactes));
            }
        }

        public static void VIEW1()
        {
            Console.WriteLine("Agrega al nuevo contacto con los siguientes datos: ");
            Console.Write("Nombre: ");
            string? name = Console.ReadLine();
            Console.Write("Apellido: ");
            Console.ReadLine();
            Console.Write("Direccion: ");
            Console.ReadLine();
            Console.Write("Telefono: ");
            Console.ReadLine();
            Console.Write("Email: ");
            Console.ReadLine();
            Console.Write("Edad: ");
            Console.ReadLine();
            Console.Write("Es pana tuyo? ");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {

            LoadData();
            int eleccion = 0;
            Console.WriteLine("Bienvenido a mi lista de Contactes");
            Console.WriteLine(@"1. Agregar Contacto     2. Ver Contactos    3. Buscar Contactos     4. Modificar Contacto   6. Eliminar Contacto    6. Salir");
            Console.WriteLine("Digite el número de la opción deseada");
            eleccion = Convert.ToInt32(Console.ReadLine());
            switch(eleccion)
            {
                case 1:
                    VIEW1();
                    break;
            }
        }
    }
}
