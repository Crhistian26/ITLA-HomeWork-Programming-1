namespace HW1_ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //#region Part 1, Declare variables

            //bool decision = true;
            //char oneCharacter = 'a';
            //string chain = "hello i am string";
            //int number = int.MaxValue;
            //long longNumber = long.MaxValue;
            //float floatNumber = float.MaxValue;
            //double doubleNumber = double.MaxValue;
            //decimal decimalNumber = decimal.MaxValue;

            //Console.WriteLine(decision);
            //Console.WriteLine(oneCharacter);
            //Console.WriteLine(chain);
            //Console.WriteLine(number);
            //Console.WriteLine(longNumber);
            //Console.WriteLine(floatNumber);
            //Console.WriteLine(doubleNumber);
            //Console.WriteLine(decimalNumber);

            //#endregion

            //#region Part 2, Const in C#
            //const string nameProgram = "Homework console program";
            
            //Console.WriteLine(nameProgram);

            ////nameProgram = "Hello";
            //#endregion

            //#region Part 3, playing with int value
            //int value = 26;
            //Console.WriteLine(value);
            //value++;
            //Console.WriteLine(value);
            //value--;
            //Console.WriteLine(value);
            //value += 5;
            //Console.WriteLine(value);
            //value -= 3;
            //Console.WriteLine(value);
            //value *= 2;
            //Console.WriteLine(value);
            //value /= 3;
            //Console.WriteLine(value);
            //#endregion

            #region Part 4, float and byte
            float firstvalue = 10152466.25f;
            byte memory = 5;

            float number = memory + firstvalue;

            Console.WriteLine(number);

            #endregion

            
        }
    }
}
