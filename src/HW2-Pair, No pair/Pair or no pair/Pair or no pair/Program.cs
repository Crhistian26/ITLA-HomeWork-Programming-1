namespace Pair_or_no_pair
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("insert one number:");
      
            try
            {
                int number = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"your number is {number}");
                if(number %  2 == 0)
                {
                    Console.WriteLine("Is Pair");
                }
                else
                {
                    Console.WriteLine("Not is Pair");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("You can't insert other value, except numbers");
            }
        }
    }
}
