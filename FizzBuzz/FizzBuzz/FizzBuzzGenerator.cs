using System.Text;

namespace FizzBuzz
{
    public class FizzBuzzGenerator
    {
        private readonly IOutputWriter _writer;

        public FizzBuzzGenerator(IOutputWriter writer)
        {
            _writer = writer;
        }

        public void Generate()
        {
            for (var i = 1; i <= 100; i++)
            {
                var sb = new StringBuilder();

                if (i % 3 == 0)
                    sb.Append("Fizz");
                if (i % 5 == 0)
                    sb.Append("Buzz");

                if (sb.Length == 0)
                    sb.Append(i);

                _writer.Write(sb.ToString());
            }
        }
    }
}