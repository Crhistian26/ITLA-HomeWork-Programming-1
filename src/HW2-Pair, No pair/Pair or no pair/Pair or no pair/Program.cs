namespace Pair_or_no_pair
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingresa un numero");
      
            try
            {
                int number = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(number);
                if(number %  2 == 0)
                {
                    Console.WriteLine("Tu numero es par");
                }
                else
                {
                    Console.WriteLine("Tu numero no es par");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("No ingresaste un numero");
            }
        }
    }
}
