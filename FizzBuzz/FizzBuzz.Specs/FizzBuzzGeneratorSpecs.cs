using System.Collections.Generic;
using SubSpec;
using Xunit;

namespace FizzBuzz.Specs
{
    public class FizzBuzzGeneratorSpecs
    {
        [Specification]
        public void PrintingSpecifications()
        {
            var outputWriter = default(OutputWriterStub);
            var sut = default(FizzBuzzGenerator);

            "given a fizzbuzz generator"
                .Context(() =>
                {
                    outputWriter = new OutputWriterStub();
                    sut = new FizzBuzzGenerator(outputWriter);
                });

            "when generating numbers one to one hundred"
                .Do(() =>
                    sut.Generate());

            "then the first item generated is the number 1"
                .Assert(() =>
                    Assert.Equal("1", outputWriter.Output[0]));

            "then the second item generated is the number 2"
                .Assert(() =>
                    Assert.Equal("2", outputWriter.Output[1]));

            "then the third item generated is the word 'Fizz'"
                .Assert(() =>
                    Assert.Equal("Fizz", outputWriter.Output[2]));

            "then the fourth item generated is the number 4"
                .Assert(() =>
                    Assert.Equal("4", outputWriter.Output[3]));

            "then the fifth item generated is the word 'Buzz'"
                .Assert(() =>
                    Assert.Equal("Buzz", outputWriter.Output[4]));

            "then the fifteen item generated is the word 'FizzBuzz'"
                .Assert(() =>
                    Assert.Equal("FizzBuzz", outputWriter.Output[14]));

            "then the thirieth item generated is the word 'FizzBuzz'"
                .Assert(() =>
                    Assert.Equal("FizzBuzz", outputWriter.Output[29]));
        }

        public class OutputWriterStub : IOutputWriter
        {
            public OutputWriterStub()
            {
                Output = new List<string>();
            }

            public void Write(string item)
            {
                Output.Add(item);
            }

            public List<string> Output { get; private set; }
        }
    }
}
