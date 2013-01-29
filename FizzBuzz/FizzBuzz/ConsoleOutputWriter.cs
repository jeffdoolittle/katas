using System;

namespace FizzBuzz
{
    public class ConsoleOutputWriter : IOutputWriter
    {
        public void Write(string item)
        {
            Console.WriteLine(item);
        }
    }
}