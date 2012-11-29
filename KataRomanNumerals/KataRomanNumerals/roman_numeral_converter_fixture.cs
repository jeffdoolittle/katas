using System.IO;
using System.Text;
using Newtonsoft.Json;
using Xunit;

namespace KataRomanNumerals
{
    public class roman_numeral_converter_fixture
    {
        protected RomanNumeralConverter ClassUnderTest;
        protected TestCase[] TestCases;

        public roman_numeral_converter_fixture()
        {
            ClassUnderTest = new RomanNumeralConverter();
            LoadTestCases();
        }

        [Fact]
        public void all_test_cases_can_be_handled()
        {
            var sb = new StringBuilder();
            var failCount = 0;

            foreach (var testCase in TestCases)
            {
                var result = ClassUnderTest.Convert(testCase.Arabic);
                if (result != testCase.Roman)
                {
                    sb.AppendFormat("Could not convert {0} to Roman number. Expected value was {1}. Actual value was {2}", testCase.Arabic, testCase.Roman, result).AppendLine();
                    failCount++;
                }
            }

            sb.Insert(0, string.Format("{0} out of {1} test cases failed.\r\n", failCount, TestCases.Length));

            Assert.True(sb.Length == 0, sb.ToString());
        }

        private void LoadTestCases()
        {
            using (var stream = (typeof(RomanNumeralConverter).Assembly.GetManifestResourceStream("KataRomanNumerals.test_cases.json")))
            {
                using (var reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    TestCases = JsonConvert.DeserializeObject<TestCase[]>(json);
                }
            }
        }

        public class TestCase
        {
            public int Arabic { get; set; }
            public string Roman { get; set; }
        }
    }
}