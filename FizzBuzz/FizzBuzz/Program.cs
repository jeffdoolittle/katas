using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new FizzBuzzGenerator(new ConsoleOutputWriter());
            generator.Generate();
            Console.ReadKey();
        }
    }
}
